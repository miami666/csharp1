using System;

namespace FlugReservierung
{
    public static class ConsoleUI
    {
        internal static void PrintStartMenu()
        {
            Console.WriteLine("Willkommen");
            Console.WriteLine("1. Kunde (neu)");
            Console.WriteLine("2. Kunde (existierend)");
            Console.WriteLine("3. Flug -> Passagierliste anzeigen");
            Console.WriteLine("4. Flughafenliste anzeigen");
        }

        internal static void PrintMainMenu()
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Menü");
            Console.WriteLine("1. Flug buchen");
            Console.WriteLine("2. suchen");
            Console.WriteLine("3. Ende");
            

        }

        public static int AskForInteger()
        {
            string input = Console.ReadLine();
            while (!Validator.CheckIfInteger(input))
            {
                Console.Clear();
                Console.WriteLine("Eingabe muss eine Zahl sein");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static string NeuerKundeName()
        {
            Console.WriteLine("Namen eingeben: ");
            string input = Console.ReadLine();
            bool askAgain = true;
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Name darf nicht leer oder numerisch sein");
                    input = Console.ReadLine();
                }
                foreach (Customer customer in CustomerList.customerList)
                {
                    if (customer.Name == input)
                    {
                        Console.WriteLine("Name existiert schon");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        askAgain = false;
                    }
                }

            } while (askAgain);
            return input;
        }

        public static string ExistierenderKundeName()
        {
            Console.WriteLine("Name:");
            foreach (Customer customer in CustomerList.customerList)
            {
                Console.WriteLine(customer.Name);
            }
            string input = Console.ReadLine();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Name darf nicht leer oder numerisch sein");
                    input = Console.ReadLine();
                }
                foreach (Customer customer in CustomerList.customerList)
                {
                    if (customer.Name == input)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Name exisistiert nicht");
                input = Console.ReadLine();
            } while (true);
        }

        public static string AskForExistingFlight()
        {
            Console.WriteLine("Flug wählen:");
            string input = Console.ReadLine();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("darf nicht leer oder numerisch seinc");
                    input = Console.ReadLine();
                }
                foreach (Flug flight in Fluggesellschaft.flugListe)
                {
                    if (flight.flugId == input)
                    {
                        return input;
                    }
                }
                Console.WriteLine("flug id nicht vorhanden");
                input = Console.ReadLine();
            } while (true);
        }

        public static string AskForSeatNumber(Flug flight)
        {
            Console.WriteLine("Sitz auswählen (z.B.: A10)");
            Console.WriteLine("Sitze die mit einem x sind vergeben");
            string input = Console.ReadLine().ToUpper();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("darf nicht leer oder numerisch sein");
                    input = Console.ReadLine().ToUpper();
                }
                if (input.Length > 1 &&
                    flight.flugzeug.Sitze.Contains(input.Substring(0, 1)) &&
                    Validator.CheckIfNumeric(input.Substring(1, input.Length - 1)))
                {
                    if (Validator.PruefSitzSchonBelegt(input, flight))
                    {
                        Console.WriteLine($"Sitz {input} schon vergeben");
                        input = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        return input;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Falsches Format");
                    input = Console.ReadLine().ToUpper();
                }
               
            } while (true);
        }
    }
}