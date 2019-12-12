using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_aufgabe_03
{
    public class ProductStock
    {
        //001_1: Member Variable.
        public string ProductName;
        private int StockInHand;

        //001_2: Multicast delegate type that 
        //get coupled with the event.
        public delegate void OnStockLow(
          object sender, EventArgs e);

        //001_3: Published event (StockLow), 
        //that takes responsibility of sending 
        //notification to the scbscriber through 
        //the above Specified multicast delegate
        public event OnStockLow StockLow;

        //001_4: Constructor that Initializes 
        //the Stock
        public ProductStock(string Name,
          int OpeningStock)
        {
            ProductName = Name;
            StockInHand = OpeningStock;
        }

        //001_5: This function reduces the stock 
        //based on the sales on the billing 
        //counters. When the stock in hand is 
        //lower than 5, it raises the 
        //StockLow event.
        public void ReduceStock(int SalesDone)
        {
            StockInHand = StockInHand - SalesDone;
            if (StockInHand < 5)
            {
                EventArgs arg = new EventArgs();
                StockLow(this, arg);
            }
        }
    }

    //002: This class is for Sales Counter 
    //that performs the Sales on different 
    //counters and makes the billing. 
    //This class Subscribes to the Published 
    //event and Receives notification through 
    //Multicast delegate.
    public class Counter
    {
        //002_1: Class member
        private string CounterName;

        //002_2: Constructor for Counter
        public Counter(string Name)
        {
            CounterName = Name;
        }

        //002_2: Function that records the sales 
        //performed on the billing desk
        public void Sales(ProductStock prod,
        int howmuch)
        {
            Console.WriteLine(
          "{0} Sold {1} numbers",
          prod.ProductName,
          howmuch);
            prod.ReduceStock(howmuch);
        }

        //002_3: Function that acts as event 
        //handler for LowStock to receive the 
        //notification
        public void LowStockHandler(
          object Sender, EventArgs e)
        {
            Console.WriteLine("Anouncement " +
            "on {0}: Stock of Product {1}" +
            " gone Low",
                CounterName,
            ((ProductStock)Sender).ProductName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Client 001: Create Billing Counters
            Counter billing_counter1 =
          new Counter("Jupiter");
            Counter billing_counter2 =
          new Counter("Saturn");

            //Client 002: Create the Product Stocks
            ProductStock prod1 = new ProductStock(
              "Godrej Fridge", 7);
            ProductStock prod2 = new ProductStock(
              "Sony CD Player", 6);
            ProductStock prod3 = new ProductStock(
              "Sony DVD", 800);

            //Client 003: Couple the Event with 
            //the Handler through the Delegate.
            prod1.StockLow +=
              new ProductStock.OnStockLow(
              billing_counter1.LowStockHandler);
            prod2.StockLow +=
              new ProductStock.OnStockLow(
              billing_counter1.LowStockHandler);
            prod1.StockLow +=
              new ProductStock.OnStockLow(
              billing_counter2.LowStockHandler);
            prod2.StockLow +=
              new ProductStock.OnStockLow(
              billing_counter2.LowStockHandler);

            //Client 004: Now Let us Start serving 
            //the customers on the Queue on 
            //each counter
            billing_counter1.Sales(prod1, 1);
            billing_counter2.Sales(prod1, 2);
            billing_counter2.Sales(prod3, 70);
            billing_counter2.Sales(prod2, 1);
            billing_counter1.Sales(prod2, 3);
            billing_counter1.Sales(prod3, 5);
            Console.ReadKey();
        }
    }
}
