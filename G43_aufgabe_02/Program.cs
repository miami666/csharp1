/*
G_43_Aufg2_Zwischenstand

    Führen Sie bitte die beiden folgenden Klassen ein:
        BankMitarbeiter
            Felder: 
                Id (öffentlich, Integer)
                Name (öffentlich, String)
                bearbeitungsCode (privat, Integer)
             Methoden:
                SetCode
                    Übergabewerte: 1 Referenz auf einen Zufallsgenerator (der im Main definiert wurde)
                    Funktion:      Weist dem Bearbeitungs-Code eine Zufallszahl zwischen 10000 und 20000 zu 
                                   Code wird dem Mitarbeiter per Mail zugesendet => simuliert durch Konsolenausgabe
                                   (HINWEIS: Nur 1-malige Zuweisung möglich)
                    Rückgabewert:  Keine 
                 GetCode
                    Übergabewert: 1 Integer code
                    Funktion:     Überprüft, ob code==bearbeitungscode
                    Rückgabewert: bearbeitungscode, FALLS code==bearbeitungscode  
                                  0 SONST 
        Konto
            Felder:
                Kontonummer (öffentlich, Integer)
                InhaberMail (öffentlich, String)
                geheimCode (privat, String)
                kontostand (privat, Double)
                dispo (privat, Double)
                Ansprechpartner (öffentlich, BankMitarbeiter)
            Property GeheimCode
                set: Setzung nur einmalig möglich, wird an den Kunden per Mail gesendet => simuliert durch Konsolenausgabe
                get: keines
            Methoden:
                SetDispo
                    Übergabewerte: Integer code, Double Dispo
                    Funktion: Vergleicht den code mit dem bearbeitungscode des Ansprechpartners => dispo wird gesetzt FALLS Codes übereinstimmen
                    Rückgabewert: true, FALLS Dispo-Zuweisung klappte, false SONST
                GetKontostand
                    Übergabewerte: keine
                    Funktion: ermittelt einen String in Abhängigkeit des Kontostandes
                    Rückgabewert: String ("keine Angabe" bei Kontostand < 0 / "wohlhabend" bei Kontostand > 100000 / "Standard" SONST)
                Einzahlen
                    Übergabewerte: Double betrag
                    Funktion: erhöht den Kontostand, FALLS betrag positiv
                    Rückgabewert: true, FALLS betrag positiv, SONST false
                Abbuchen
                    Übergabewerte: Double betrag, String code
                    Funktion: vermindert den Kontostand um betrag FALLS a) code == geheimcode b) kontostand-betrag nicht den dispo überzieht
                    Rückgabewert: true, FALLS betrag abgezogen werden konnte, SONST false
                
      Im Main:
        Führen Sie bitte (mindestens) einen Bankmitarbeiter und ein Konto ein
        Füllen Sie von allen Objekten alle Felder
        Testen Sie bitte durch geeigneten Code alle Methoden

        HINWEIS:
            Sie können es sich beim Testlauf im Main (falls Sie möchten) gerne leicht machen!
            (Ein aufwendiges Eingabemenü wird nicht zwingend verlangt ... aber gene genommen ;-)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_43_Aufg2
{

    class Konto
    {
        int counter = 0;

        public int Kontonummer;
        public string InhaberMail;
        string geheimCode;
        double kontostand;
        double dispo;
        public BankMitarbeiter Ansprechpartner;

        //Property GeheimCode
        //        set: Setzung nur einmalig möglich, wird an den Kunden per Mail gesendet => simuliert durch Konsolenausgabe
        //        get: keines
        public string GeheimCode
        {
            set
            {
                if (counter == 0)
                {
                    geheimCode = value;
                    Console.WriteLine("Mail an den Bank-Kunden: Geheimcode:" + geheimCode);
                }
                else Console.WriteLine("Mail an den Bank-Kunden: Geheimcode konnte nicht geändert werden!");
                counter++;
            }
        }

        //SetDispo
        //Übergabewerte: Integer code, Double Dispo
        //Funktion: Vergleicht den code mit dem bearbeitungscode des Ansprechpartners => dispo wird gesetzt FALLS Codes übereinstimmen
        //Rückgabewert: true, FALLS Dispo-Zuweisung klappte, false SONST

        public bool SetDispo(int code, double dispo)
        {
            if (code == Ansprechpartner.GetCode(code))
            {
                this.dispo = dispo;
                return true;
            }
            return false;
        }
        public double GetDispo()
        {
            return dispo;
        }


        //GetKontostand
        //            Übergabewerte: keine
        //            Funktion: ermittelt einen String in Abhängigkeit des Kontostandes
        //            Rückgabewert: String("keine Angabe" bei Kontostand < 0 / "wohlhabend" bei Kontostand > 100000 / "Standard" SONST)
        public string GetKontostand()
        {
            if (kontostand < 0) return "keine Angabe";
            if (kontostand > 100000) return "wohlhabend";
            return "Standard";
        }


        //        Einzahlen
        //            Übergabewerte: Double betrag
        //            Funktion: erhöht den Kontostand, FALLS betrag positiv
        //            Rückgabewert: true, FALLS betrag positiv, SONST false
        public bool Einzahlen(double betrag)
        {
            if (betrag > 0)
            {
                kontostand += betrag;
                return true;
            }
            return false;
        }


        //        Abbuchen
        //            Übergabewerte: Double betrag, String code
        //            Funktion: vermindert den Kontostand um betrag FALLS a) code == geheimcode b) kontostand-betrag nicht den dispo überzieht
        //            Rückgabewert: true, FALLS betrag abgezogen werden konnte, SONST false

        public bool Abbuchen(double betrag, string code)
        {
            if (code == geheimCode && kontostand + dispo >= betrag)
            {
                kontostand -= betrag;
                return true;
            }
            return false;
        }

    } // Ende class Konto



    class BankMitarbeiter
    {
        //Felder: 
        int counter = 0;

        public int Id;
        public string Name;
        int bearbeitungsCode;

        //     Methoden:

        //SetCode
        //   Übergabewerte: 1 Referenz auf einen Zufallsgenerator(der im Main definiert wurde)
        //   Funktion:      Weist dem Bearbeitungs-Code eine Zufallszahl zwischen 10000 und 20000 zu
        //                 Code wird dem Mitarbeiter per Mail zugesendet => simuliert durch Konsolenausgabe
        //                       (HINWEIS: Nur 1-malige Zuweisung möglich)
        //   Rückgabewert:  Keine
        public void SetCode(ref Random zf)
        {
            if (counter == 0)
            {
                bearbeitungsCode = zf.Next(10000, 20001);
                counter++;
            }
            Console.WriteLine("Mail an BankMitarbeiter - Code:" + bearbeitungsCode);
        }

        //GetCode
        //   Übergabewert: 1 Integer code
        //   Funktion:     Überprüft, ob code==bearbeitungscode
        //   Rückgabewert: bearbeitungscode, FALLS code==bearbeitungscode  
        //                 0 SONST

        public int GetCode(int code)
        {
            if (code == bearbeitungsCode) return bearbeitungsCode;
            return 0;
        }

    } // Ende class BankMitarbeiter


    class Program
    {
        static void Main(string[] args)
        {
            //    Im Main:
            //Führen Sie bitte(mindestens) einen Bankmitarbeiter und ein Konto ein
            //Füllen Sie von allen Objekten alle Felder
            //Testen Sie bitte durch geeigneten Code alle Methoden
            int eingabe;
            string code;
            Random zf = new Random(Guid.NewGuid().GetHashCode());
            BankMitarbeiter bm = new BankMitarbeiter();
            bm.Id = 1;
            bm.Name = "Richard S Fuld";
            bm.SetCode(ref zf);

            Konto k = new Konto();
            k.Kontonummer = 012345;
            k.InhaberMail = "konto@mail.com";
            k.GeheimCode = "XYZ1247";
            k.Ansprechpartner = bm;
            k.Einzahlen(1000000);
            Console.WriteLine("Authorisierungscode: ");
            eingabe = Convert.ToInt32(Console.ReadLine());
            k.SetDispo(eingabe, 20000);


            Console.WriteLine("Get Kontostand: " + k.GetKontostand());
            Console.WriteLine("GetDispo: " + k.GetDispo());

            Console.ReadKey();
        }
    }
}