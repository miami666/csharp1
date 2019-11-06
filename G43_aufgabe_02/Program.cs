using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
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
namespace G43_aufgabe_02
{
    class BankMitarbeiter
    {
        public int Id;
        public string Name;
        private int bearbeitungscode;

        public void SetCode(int zufallszahl)
        {
            int counter = 0;
            if (counter == 0)
            {
                bearbeitungscode = zufallszahl;
                counter++;
                Console.WriteLine(bearbeitungscode);
                
            }
            else
            {

            }

        }
        public int GetCode(int code)
        {
          
            return bearbeitungscode;
        }

    }
    class Konto
    {
        public int Kontonummer;
        public string InhaberMail;
        private string geheimCode;
        private double kontostand;
        private double dispo;
        public string Ansprechpartner;
        public int counter = 0;
        public string GeheimCode
        {
            set
            {
                if (geheimCode != null) geheimCode = value;
            }
        }
        public bool SetDispo(int code,double dispo)
        {
            bool b=false;
            return b;
        }
        public string GetKontostand()
        {
            string r;
            if(kontostand<0)
            {
                r = "keine Angabe";
            }
            else if(kontostand>100000)
            {
                r = "wohlhabend";
            }
            else
            {
                r = "Standard";
            }
            return r;
        }
        public bool einzahlen(double betrag)
        {
            bool b = false;
            if(betrag >0)
            {
                kontostand = kontostand + betrag;
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }
        public bool abbuchen(double betrag,string code)
        {
            bool b = false;
            if(code==geheimCode && kontostand-betrag>=dispo)
            {
                kontostand = kontostand - betrag;
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random zufallsGenerator = new Random();
            int zufallszahl = zufallsGenerator.Next(10000, 20000);
            BankMitarbeiter a = new BankMitarbeiter();
            a.SetCode(zufallszahl);
            Console.ReadKey();

        }
    }
}
