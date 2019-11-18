using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die folgenden 4 Klassen ein:

        Klasse TextAusgabe
            Member 
                1 öffentlicher String Text
                1 öffentliche Methode:
                    Name: Schreibe
                    Übergabewerte: keine
                    Funktion: Gibt den String Text auf der Konsole aus
                    Rückgabewert: keiner
        
         Klasse PositionierteTextAusgabe (erbt von TextAusgabe)
            Member
                2 öffentliche Integer x und y
                1 öffentliche Methode:
                    Name: SetzeCursorUndSchreibe
                    Übergabewerte: keine
                    Funktion: - setzt den Cursor auf Position (X,Y)
                              - ruft die Methode Schreibe() auf
                    Rückgabewert: keiner

         Klasse PositionierteStringAbfrage (erbt von PositionierteTextAusgabe) 
            Member
                1 öffentliche Methode:
                    Name: SetzeCursorUndSchreibeDannStringAbfrage
                    Übergabewerte: keine
                    Funktion: - ruft die Methode SetzeCursorUndSchreibe() auf
                              - fragt vom User einen String ab
                    Rückgabewert: User-Eingabe 
           
          Klasse PositionierteIntegerAbfrage (erbt von PositionierteStringAbfrage) 
            Member
                1 öffentliche Methode:
                    Name: SetzeCursorUndSchreibeDannStringAbfrageDieGeparsedWird
                    Übergabewerte: keine
                    Funktion: - ruft die Methode SetzeCursorUndSchreibeDannStringAbfrage() auf
                              - parsed den Rückgabewert von SetzeCursorUndSchreibeDannStringAbfrage() in einen Integer x
                                (Hinweis: x wird auf 0 gesetzt, falls Parse-Vorgang scheitert ) 
                    Rückgabewert: x
                    
  Im Main
    - Instanziiert ein Objekt vom Typ PositionierteIntegerAbfrage
    - Weist dem Feld Text den String "Geben Sie bitte eine ganze Zahl ein: " zu
    - Setzt X und Y auf 2
    - Ruft die Methode SetzeCursorUndSchreibeDannStringAbfrageDieGeparsedWird() auf und gibt deren Rückgabewert zur Kontrolle auf der Konsole aus
*/
namespace vererbung_aufgabe_3
{
    class TextAusgabe
    {
        public string text;
        public void Schreibe()
        {
            Console.WriteLine(text);
        }

    }
    class PositionierteTextAusgabe:TextAusgabe
    {
        public int x, y;
        public void SetzeCursorSchreibe()
        {
            Console.SetCursorPosition(x, y);
            Schreibe();
        }


    }
    class PositionierteStringabfrage:PositionierteTextAusgabe
    {
        public string SetzeCursorUndSchreibeDannStringAbfrage()
        {
            Console.WriteLine(text);
            string input = Console.ReadLine();
            SetzeCursorSchreibe();
            return input;

        }

    }
    class PositionierteIntegerAbfrage:PositionierteStringabfrage
    {
        public int SetzeCursorUndSchreibeDannStringAbfrageDieGeparsedWird()
        {
            do
            {
                
                SetzeCursorUndSchreibeDannStringAbfrage();
               
                return x;
               
            }
            while(!int.TryParse(SetzeCursorUndSchreibeDannStringAbfrage(), out x));

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            PositionierteIntegerAbfrage a = new PositionierteIntegerAbfrage();
            a.text = "Geben Sie bitte eine ganze Zahl ein: ";
            a.x = 2;
            a.y = 2;
            Console.WriteLine(a.SetzeCursorUndSchreibeDannStringAbfrageDieGeparsedWird());
            Console.ReadKey();
        }
    }
}
