using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiseBuero
{
    class Program
    {
        static void Main(string[] args)
        {
            FlugOrder.FlugEntity[] anItem = new FlugOrder.FlugEntity[20];

            // We will use a string to categorize each item
            string Category = "Unknown";
            long ItemID = 0;
           
            decimal Price = 0.00M;

            new FlugOrder.FlugEntity(1, "Spanien", 275.25M, "14/06/2019", new DateTime(2019, 06, 14, 12, 0, 0), new DateTime(2019, 06, 14, 16, 0, 0), 12);
           
            anItem[0] = new FlugOrder.FlugEntity();
            anItem[0].ID = 947783;
            anItem[0].Flugziel = "Spanien";
            anItem[0].Preis = 275.25M;

            anItem[1] = new FlugOrder.FlugEntity();
            anItem[1].ID = 934687;
            anItem[1].Flugziel = "Floral Silk Tank Blouse   ";
            anItem[1].Preis = 180.00M;

            anItem[2] = new FlugOrder.FlugEntity();
            anItem[2].ID = 973947;
            anItem[2].Flugziel = "Push Up Bra               ";
            anItem[2].Preis = 50.00M;

            anItem[3] = new FlugOrder.FlugEntity();
            anItem[3].ID = 987598;
            anItem[3].Flugziel = "Chiffon Blouse            ";
            anItem[3].Preis = 265.00M;

            anItem[4] = new FlugOrder.FlugEntity();
            anItem[4].ID = 974937;
            anItem[4].Flugziel = "Bow Belt Skirtsuit        ";
            anItem[4].Preis = 245.55M;

            anItem[5] = new FlugOrder.FlugEntity();
            anItem[5].ID = 743765;
            anItem[5].Flugziel = "Cable-knit Sweater        ";
            anItem[5].Preis = 45.55M;

            anItem[6] = new FlugOrder.FlugEntity();
            anItem[6].ID = 74;
            anItem[6].Flugziel = "Jeans with Heart Belt     ";
            anItem[6].Preis = 25.65M;

            anItem[7] = new FlugOrder.FlugEntity();
            anItem[7].ID = 765473;
            anItem[7].Flugziel = "Fashionable mini skirt    ";
            anItem[7].Preis = 34.55M;

            anItem[8] = new FlugOrder.FlugEntity();
            anItem[8].ID = 754026;
            anItem[8].Flugziel = "Double Dry Pants          ";
            anItem[8].Preis = 28.55M;

            anItem[9] = new FlugOrder.FlugEntity();
            anItem[9].ID = 730302;
            anItem[9].Flugziel = "Romantic Flower Dress     ";
            anItem[9].Preis = 24.95M;

            anItem[10] = new FlugOrder.FlugEntity();
            anItem[10].ID = 209579;
            anItem[10].Flugziel = "Cotton Polo Shirt         ";
            anItem[10].Preis = 45.75M;

            anItem[11] = new FlugOrder.FlugEntity();
            anItem[11].ID = 267583;
            anItem[11].Flugziel = "Pure Wool Cap             ";
            anItem[11].Preis = 25.00M;

            anItem[12] = new FlugOrder.FlugEntity();
            anItem[12].ID = 248937;
            anItem[12].Flugziel = "Striped Cotton Shirt      ";
            anItem[12].Preis = 65.55M;

            anItem[13] = new FlugOrder.FlugEntity();
            anItem[13].ID = 276057;
            anItem[13].Flugziel = "Two-Toned Ribbed Crewneck ";
            anItem[13].Preis = 9.75M;

            anItem[14] = new FlugOrder.FlugEntity();
            anItem[14].ID = 267945;
            anItem[14].Flugziel = "Chestnut Italian Shoes    ";
            anItem[14].Preis = 165.75M;

            anItem[15] = new FlugOrder.FlugEntity();
            anItem[15].ID = 409579;
            anItem[15].Flugziel = "Collar and Placket Jacket ";
            anItem[15].Preis = 265.15M;

            anItem[16] = new FlugOrder.FlugEntity();
            anItem[16].ID = 467583;
            anItem[16].Flugziel = "Country Coat Rugged Wear  ";
            anItem[16].Preis = 35.55M;

            anItem[17] = new FlugOrder.FlugEntity();
            anItem[17].ID = 448937;
            anItem[17].Flugziel = "Carpenter Jeans           ";
            anItem[17].Preis = 24.95M;

            anItem[18] = new FlugOrder.FlugEntity();
            anItem[18].ID = 476057;
            anItem[18].Flugziel = "Dbl-Cushion Tennis Shoes  ";
            anItem[18].Preis = 48.75M;

            anItem[19] = new FlugOrder.FlugEntity();
            anItem[19].ID = 467945;
            anItem[19].Flugziel = "Stitched Center-Bar Belt  ";
            anItem[19].Preis = 32.50M;

            // Order Processing
            // Request an item number from the user
            try
            {
                Console.Write("Enter Item Number: ");
                ItemID = long.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number - The program will terminate\n");
            }

            // Scan the list
            for (int i = 0; i < 20; i++)
            {
                // Find out if the number typed exists in the list
                if (ItemID == anItem[i].ID)
                {
                    // If the number matches one of the numbers in the list
                    // Create a FlugEntity value from it
                    Description = anItem[i].Flugziel;
                    Price = anItem[i].Preis;

                    // Identify the category of the item
                    if (ItemID >= 900000)
                        Category = "Women";
                    else if (ItemID >= 700000)
                        Category = "Girls";
                    else if (ItemID >= 400000)
                        Category = "Boys";
                    else
                        Category = "Men";
                }
            }

            // Display the receipt
            Console.WriteLine("Receipt");
            Console.WriteLine("Item Number: {0}", ItemID);
            Console.WriteLine("Description: {0} - {1}", Category, Description);
            Console.WriteLine("Unit Price:  {0:C}\n", Price);
            Console.ReadKey();
 
        }
    }
}
