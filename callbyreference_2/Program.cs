using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace callbyreference_2
{


    /*######################################################################################
                //G_21_CallByReference
                /*
                    Call By Reference

                    VORBEMERKUNG zum Begriff des Seiteneffektes:
                    Immer dann, wenn der bloße Aufruf einer Funktion bereits einen Effekt(= eine "Wirkung"(*)) zeigt, so sprechen
                    wir von einem "Seiteneffekt". Um dies von Funktionen abgrenzen zu können, die einen solchen Effekt nicht besitzen
                    schauen wir uns zunächst eine Funktion 'Summe' an, die zwar etwas berechnet, einen Rückgabewert liefert 
                    (und also Zeit verbraucht) aber beim bloßen Aufruf keine Wirkung zeigt.

                    (*) Wirkung im Sinn von:
                    - Konsolen-Ausgabe
                    - Einträge in einer Text-Datei
                    - Starten eines Druck-Vorganges
                    - ...
                    - ODER: Veränderung des Wertes einer "lokalen Variable" 
                    (also einer Variable, die nur dort gültig ist, wo die Funktion aufgerufen wurde, NICHT aber innerhalb der Funktion)

                    DEFINITION des Begriffes "Call By Reference" (in Abgrenzung zu "Call By Value")
                    Immer dann, wenn der bloße Aufruf einer Funktion einen Wert ändert, der "eigentlich" nur dort gültig ist, 
                    wo die Funktion aufgerufen wurde sprechen wir von einer Call By Reference-Methode(bzw. Funktion, oder Operation). 

                */

    class Program
    {

        static int Summe(int a, int b)
        {
            return a + b;
        }
        static int Plus1_CallByValue(int wert)
        {
            return wert + 1;
        }
        static void Plus1_CallByReference(ref int referenz)
        {
            referenz = referenz + 1;
        }
        static void Plus1_CallByOut(out int referenz)
        {
            referenz = 1;
        }
        static void setze1_CallByRef(ref int referenz)
        {
            referenz = 1;
        }
        static void Plus_1_CallByReference_OUT(out int referenz)
        {
            referenz = 5;
            referenz++;
        }
        static void macheirgendwas_OUT(ref int referenz)
        {
            Console.WriteLine("PalimPalim");
        }

        static void Main(string[] args)
        {
            // Aufruf der Funktion Summe:
            Summe(2, 5);
            // Diese Funktion berechnet nun zwar den Rückgabewert 7, 
            // dieser wird aber nicht abgespeichert, nicht auf der Konsole ausgegeben
            // nicht in eine Textdatei eingetragen, nicht von einem Drucker ausgegeben ... 
            // => KEIN Seiteneffekt

            // Falls wir den Rückgabewert "abfangen", ihn also einer Variable zuweisen, 
            // so handelt es sich natürlich NICHT mehr um einen bloßen 
            // Funktions-Aufruf, sondern um einen Aufruf+Zuweisung ... 
            // das soetwas dann einen Effekt hat, ist selbstverständlich 
            int rückgabewertMerkVariable = Summe(2, 5);
            // BEMERKUNG:
            // Wenn man eine Funktion aufruft, die einen Rückgabewert zurück liefert, 
            // dann kann man sich den Aufruf anschaulich wie folgt vorstellen:
            // a) Mit dem Aufruf springt der Compiler von der Stelle, 
            //    wo die Funktion aufgerufen wird hin zu der Stelle, wo die Funktion definiert ist
            // b) NACH der Abarbeitung der Funktion, springt der Compiler zu seinem Ausgangspunkt zurück 
            //    und trägt dort den Rückgabewert ein
            //    => hier: Der Rückgabewert (7) steht nun an der Stelle, wo bisher Summe(2,5) stand 
            //    => Anstelle von    int rückgabewertMerkVariable = Summe(2, 5);
            //       steht nun:      int rückgabewertMerkVariable = 7;    


            //  Deklaration, Definition und Initialisierung der lokalen Variable  wert & zuFuellendeVariable
            int wert = 11;
            int zuFuellendeVariable;
            int wert_UNINITIALISIERT;

            Plus1_CallByValue(wert);
            zuFuellendeVariable = Plus1_CallByValue(wert);
            Console.WriteLine("Kontrollausgabe:"+zuFuellendeVariable+"\t"+wert);

            Plus1_CallByReference(ref wert);
            Console.WriteLine("Kontrollausgabe call by reference "+wert);

            //mit out 
            Plus1_CallByOut(out wert);
            Console.WriteLine("Kontrolle mit OUT:"+wert);

            Plus1_CallByOut(out wert_UNINITIALISIERT);
            Console.WriteLine("Kontrolle mit OUT:" + wert_UNINITIALISIERT);

            setze1_CallByRef(ref wert);
            Console.WriteLine("Kontrollausgabe call by reference setze 1 " + wert);


            Plus_1_CallByReference_OUT(out wert);
            Console.WriteLine(wert);

            macheirgendwas_OUT(out wert);



            Console.ReadKey();

        }
    }
}



