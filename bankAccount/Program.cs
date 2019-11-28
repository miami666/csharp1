using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            App();
        }

        public static void App()
        {
            BankDetails bankdet = new BankDetails();

            ShowMenu();

            while (true)
            {
                Console.WriteLine("");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "a":
                        Console.WriteLine("'Citire din fisier' selected");
                        break;
                    case "b":
                        Console.WriteLine("'Creare cont' selected");
                        Console.WriteLine("");
                        bankdet.CreateAccount("Name 1");
                        bankdet.CreateAccount("Name 2");
                        bankdet.CreateAccount("");
                        bankdet.CreateAccount("Name 4");
                        bankdet.CreateAccount("Name 5");
                        break;
                    case "c":
                        Console.WriteLine("'Depunere bancara' selected");
                        bankdet.Deposit();
                        break;
                    case "d":
                        Console.WriteLine("'Retragere bancara' selected");
                        bankdet.Withdraw();
                        break;
                    case "e":
                        Console.WriteLine("'Afisare sold' selected");
                        bankdet.Balance();
                        break;
                    case "f":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("a. Citire din fisier");
            Console.WriteLine("b. Creare cont");
            Console.WriteLine("c. Depunere bancara");
            Console.WriteLine("d. Retragere bancara");
            Console.WriteLine("e. Afisare sold");
            Console.WriteLine("f. Iesire");
        }

    }
}
