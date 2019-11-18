//-------------- (jagged (arrays) ----------------
/*
 Aufg: familienArraynmitglieder im array abspeichern und auslesen und suchen
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whd1
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 2-dim array
            //string[,] familienArray = new string[3, 5];

            //string[,] familienArray_mit_init = new string[3, 5]
            //{
            //    {"otto", "werner", "Anna", "Marie","Bello" },
            //    {"tom", "thomas", "Auguste", "Santa","TinkerBell" },
            //    {"Antonia", "Thor", "Loki", "Hans","Odin" }
            //};

            //// familienArray füllen
            //for (int i = 0; i < 3; i++) // durch familien rennen
            //    for (int j = 0; j < 5; j++) // durch Namen rennen
            //    {
            //        Console.Write("Bitte geben Sie den {0}. Namen der {1}. Familie ein:", j + 1, i + 1);
            //        familienArray[i, j] = Console.ReadLine();
            //    }

            //// alle 3 familien ausgeben
            //for (int i = 0; i < 3; i++) // durch familie rennen
            //{
            //    Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
            //    for (int j = 0; j < 5; j++) // durch Namen rennen
            //    {
            //        Console.WriteLine(familienArray[i, j]);
            //    }
            //}

            //Console.Write("\n\n");
            //// alle 3 Familien von familienArray_mit_init ausgeben
            //for (int i = 0; i < 3; i++) // durch familie rennen
            //{
            //    Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
            //    for (int j = 0; j < 5; j++) // durch Namen rennen
            //    {
            //        Console.WriteLine(familienArray_mit_init[i, j]);
            //    }
            //}

            //////////////////////////////////////////////////////////////////////////

            // 2-dim Jagged Array 'familienArray1Jagged'
            string[][] familienArray1Jagged = new string[3][];
            familienArray1Jagged[0] = new string[3];
            familienArray1Jagged[1] = new string[4];
            familienArray1Jagged[2] = new string[5];

            // Eingabe
            for (int i = 0; i < familienArray1Jagged.Length; i++)
                for (int j = 0; j < familienArray1Jagged[i].Length; j++)
                {
                    Console.Write("Bitte geben Sie den {0}. Namen der {1}. familienArray ein:", j + 1, i + 1);
                    familienArray1Jagged[i][j] = Console.ReadLine();
                }

            // Ausgabe
            Console.Write("\n\n");
            // alle 3 Familien von familienArray1Jagged ausgeben
            for (int i = 0; i < familienArray1Jagged.Length; i++) // durch familie rennen
            {
                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
                for (int j = 0; j < familienArray1Jagged[i].Length; j++) // durch Namen rennen
                {
                    Console.WriteLine(familienArray1Jagged[i][j]);
                }
            }


            // nochmal mit init
            // 2-dim Jagged Array 'familienArray2Jagged'
            string[][] familienArray2Jagged = new string[3][];
            familienArray2Jagged[0] = new string[] { "aa", "bb", "cc" };
            familienArray2Jagged[1] = new string[] { "GG", "bäb", "cöc", "JKR" };
            familienArray2Jagged[2] = new string[] { "aßa", "bÜb", "Öcc", "potter", "resi", "ompf" };

            // Ausgabe
            Console.Write("\n\n");
            // alle 3 Familien von familienArray2Jagged ausgeben
            for (int i = 0; i < familienArray2Jagged.Length; i++) // durch familie rennen
            {
                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
                for (int j = 0; j < familienArray2Jagged[i].Length; j++) // durch Namen rennen
                {
                    Console.WriteLine(familienArray2Jagged[i][j]);
                }
            }
           // Object Search = "z";
           // int myIndex = Array.BinarySearch(familienArray1Jagged, Search);
           // if (myIndex < 0)
           //     Console.WriteLine("Das Gesuchte ({0}) wurde nicht gefunden.", Search);
           // else
            //    Console.WriteLine("Das Gesuchte ({0}) wurde an Index {1} gefunden.", Search, myIndex);
            bool exists = familienArray1Jagged.Any(i => i.Contains("z"));
            if (exists)
            {
                Console.WriteLine("gibts");

            }
            else
            {
                Console.WriteLine("nope");
            }


            Console.ReadKey();
        }
    }
}


// Wiederholungen

//-------------- (jagged (arrays) ----------------
/*
 Aufg: familienArraynmitglieder im array abspeichern und auslesen und suchen
 */
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace whd1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // 2-dim array
//            string[,] familienArray = new string[3, 5];

//            string[,] familienArray_mit_init = new string[3, 5]
//            {
//                {"otto", "werner", "Anna", "Marie","Bello" },
//                {"tom", "thomas", "Auguste", "Santa","TinkerBell" },
//                {"Antonia", "Thor", "Loki", "Hans","Odin" }
//            };

//            // familienArray füllen
//            for (int i = 0; i < 3; i++) // durch familien rennen
//                for (int j = 0; j < 5; j++) // durch Namen rennen
//                {
//                    Console.Write("Bitte geben Sie den {0}. Namen der {1}. Familie ein:", j + 1, i + 1);
//                    familienArray[i, j] = Console.ReadLine();
//                }

//            // alle 3 familien ausgeben
//            for (int i = 0; i < 3; i++) // durch familie rennen
//            {
//                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
//                for (int j = 0; j < 5; j++) // durch Namen rennen
//                {
//                    Console.WriteLine(familienArray[i, j]);
//                }
//            }

//            Console.Write("\n\n");
//            // alle 3 Familien von familienArray_mit_init ausgeben
//            for (int i = 0; i < 3; i++) // durch familie rennen
//            {
//                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
//                for (int j = 0; j < 5; j++) // durch Namen rennen
//                {
//                    Console.WriteLine(familienArray_mit_init[i, j]);
//                }
//            }

//            //////////////////////////////////////////////////////////////////////////

//            // 2-dim Jagged Array 'familienArray1Jagged'
//            string[][] familienArray1Jagged = new string[3][];
//            familienArray1Jagged[0] = new string[3];
//            familienArray1Jagged[1] = new string[4];
//            familienArray1Jagged[2] = new string[5];

//            // Eingabe
//            for (int i = 0; i < familienArray1Jagged.Length; i++)
//                for (int j = 0; j < familienArray1Jagged[i].Length; j++)
//                {
//                    Console.Write("Bitte geben Sie den {0}. Namen der {1}. familienArray ein:", j + 1, i + 1);
//                    familienArray1Jagged[i][j] = Console.ReadLine();
//                }

//            // Ausgabe
//            Console.Write("\n\n");
//            // alle 3 Familien von familienArray1Jagged ausgeben
//            for (int i = 0; i < familienArray1Jagged.Length; i++) // durch familie rennen
//            {
//                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
//                for (int j = 0; j < familienArray1Jagged[i].Length; j++) // durch Namen rennen
//                {
//                    Console.WriteLine(familienArray1Jagged[i][j]);
//                }
//            }


//            // nochmal mit init
//            // 2-dim Jagged Array 'familienArray2Jagged'
//            string[][] familienArray2Jagged = new string[3][];
//            familienArray2Jagged[0] = new string[] { "aa", "bb", "cc" };
//            familienArray2Jagged[1] = new string[] { "GG", "bäb", "cöc", "JKR" };
//            familienArray2Jagged[2] = new string[] { "aßa", "bÜb", "Öcc", "potter", "resi", "ompf" };

//            // Ausgabe
//            Console.Write("\n\n");
//            // alle 3 Familien von familienArray2Jagged ausgeben
//            for (int i = 0; i < familienArray2Jagged.Length; i++) // durch familie rennen
//            {
//                Console.WriteLine("Mitglieder der " + (i + 1) + ". Familie:");
//                for (int j = 0; j < familienArray2Jagged[i].Length; j++) // durch Namen rennen
//                {
//                    Console.WriteLine(familienArray2Jagged[i][j]);
//                }
//            }

//            ///////////////////////////////////////////////

//            // Namen suchen in familienArray_mit_init
//            Console.Write("\n\nWelchen Namen suchen sie? :");
//            string name = Console.ReadLine();
//            bool gefunden = false;

//            for (int i = 0; i < 3; i++) // durch familie rennen
//            {
//                for (int j = 0; j < 5; j++) // durch Namen rennen
//                {
//                    //if (familienArray_mit_init[i, j]==name)
//                    //if (familienArray_mit_init[i, j].Contains(name)==true)
//                    if (familienArray_mit_init[i, j].Contains(name))
//                    {
//                        Console.WriteLine(familienArray_mit_init[i, j] + " gehört zur " + (i + 1) + ". Familie.");
//                        gefunden = true;
//                    }
//                }
//            }

//            if (gefunden == false) Console.WriteLine(name + " nicht gefunden");



//            Console.ReadKey();
//        }
//    }
//}



