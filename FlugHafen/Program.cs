using System;
using System.Collections.Generic;

namespace FlugReservierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Fluggesellschaft.AddHafen(new Flughafen("BER"));
            Fluggesellschaft.AddHafen(new Flughafen("WAW"));
            DateTime departure = new DateTime(2019, 6, 1, 7, 47, 0);
            DateTime arrival = new DateTime(2019, 6, 1, 12, 4, 0);
            IFlugzeug plane = new Boeing();
            Flug flight = new Flug("WAW", "LIS", departure, arrival, 902.2f, plane);
            Fluggesellschaft.Add(flight);
            departure = new DateTime(2019, 7, 1, 12, 42, 22);
            arrival = new DateTime(2019, 7, 1, 15, 14, 21);
            plane = new Boeing();
            plane.AddBelegterSitz("A9");
            plane.AddBelegterSitz("B10");
            flight = new Flug("WAW", "LON", departure, arrival, 732.5f, plane);
            Fluggesellschaft.Add(flight);
            departure = new DateTime(2019, 7, 1, 08, 22, 22);
            arrival = new DateTime(2019, 7, 1, 09, 15, 13);
            IFlugzeug plane2 = new Airbus();
            plane2.AddBelegterSitz("A9");
            plane2.AddBelegterSitz("B9");
            flight = new Flug("WAW", "GDA", departure, arrival, 412.5f, plane2);
            Fluggesellschaft.Add(flight);

            CustomerList.AddCustomer(new Customer("a"));
            CustomerList.AddCustomer(new Customer("b"));

            string customerName = "";
            Customer customer = new Customer("");
            while (true)
            {
                ConsoleUI.PrintStartMenu();
                int input = ConsoleUI.AskForInteger();
                bool askAgain = true;
                bool back = true;
                do
                    switch (input)
                    {
                        case 1:
                            customerName = ConsoleUI.NeuerKundeName();
                            customer = new Customer(customerName);
                            CustomerList.AddCustomer(customer);
                            askAgain = false;
                            break;
                        case 2:
                            customerName = ConsoleUI.ExistierenderKundeName();
                            customer = CustomerList.customerList.Find(cust => cust.Name == customerName);
                            askAgain = false;
                            break;
                        case 3:
                            Console.WriteLine(Fluggesellschaft.ToString());
                            Console.WriteLine("Flugliste");
                            string choosenFlight = ConsoleUI.AskForExistingFlight();
                            flight = Fluggesellschaft.flugListe.Find(fly => fly.flugId == choosenFlight);
                            foreach (var item in flight.Flugpassagiere)
                            {
                                Console.WriteLine(item);
                            }
                            askAgain = false;
                            break;
                        case 4:



                            foreach (var item in Fluggesellschaft.flughafenListe)
                            {
                                Console.WriteLine(item.kennung);

                            }
                            back = false;
                            askAgain = false;
                            ConsoleUI.PrintStartMenu();
                            input = ConsoleUI.AskForInteger();

                            break;
                        default:
                            Console.WriteLine("Falsche Auswahl");
                            input = ConsoleUI.AskForInteger();
                            break;
                    } while (askAgain);


                ConsoleUI.PrintMainMenu();
                input = ConsoleUI.AskForInteger();
                askAgain = true;
                do
                    switch (input)
                    {

                        case 1:

                            Console.WriteLine(Fluggesellschaft.ToString());
                            Console.WriteLine("Flugliste");
                            string choosenFlight = ConsoleUI.AskForExistingFlight();
                            flight = Fluggesellschaft.flugListe.Find(fly => fly.flugId == choosenFlight);
                            flight.flugzeug.ZeigeSitze();

                            string seatId = ConsoleUI.AskForSeatNumber(flight);
                            flight.flugzeug.AddBelegterSitz(seatId);
                            customer.BookFlight(flight, seatId, customer.Name);
                            flight.flugzeug.ZeigeSitze();
                            ConsoleUI.PrintMainMenu();
                            input = ConsoleUI.AskForInteger();
                            break;
                        case 2:
                            foreach (var item in customer.BookedFlights)
                            {
                                Console.WriteLine(item.Key.flugId);
                                foreach (var temp in item.Value)
                                {
                                    Console.WriteLine(temp);
                                }
                            }
                            ConsoleUI.PrintMainMenu();
                            input = ConsoleUI.AskForInteger();
                            break;
                        case 3:
                            askAgain = false;
                            break;

                        default:
                            Console.WriteLine("Falsche Auswahl");
                            input = ConsoleUI.AskForInteger();
                            break;
                    } while (askAgain);

                Console.WriteLine("Nächste Runde");
                Console.ReadLine();
            }
        }
        private static int GetUserChoice(string question, int choice)
        {
            Console.WriteLine(question);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
