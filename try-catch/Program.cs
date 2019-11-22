/*
Try-Catch-Finally

    ERLÄUTERUNG
    Immer dann, wenn in einem (C#)-Programm etwas unzulässiges geschieht, stürzt das Programm ab.
    Das kann Folge eines Programmierfehlers sein 
    (der dann natürlich behoben werden kann und der "hoffentlich" bereits im Testlauf auffiel) ...
    ... es kann aber auch "externe" Gründe geben 
    (unzulässige User-Eingaben, Werte, die aus einer Datenbank/einem Textfile gelesen werden ...)

    Solche externen Fehler können wir zwar nicht ausschließen, aber wenigstens "abfangen"(catch) 
    => Programm stürzt nicht ab, sondern wir bestimmen, "wie es weitergeht" 
    (Eigene Fehlermeldung, erneute Input-Abfrage ...)

    ERINNERUNG
    Das ganze erinnert an TryParse, wo wir ebenfalls einen Befehl "versuchen"(try) 
    und bei einem Rückgabewert 'false' selbst entscheiden können,
    wie wir auf diese Fehlermeldung reagieren (ohne dass eben das Programm ungewollt abstürzte)
*/
using System;


namespace G_71_Try_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Eine erste Fehler-Provokation: Teilen durch Null 
            // Dieser Fehler wird (aus Sicht der Präsentation "leider") zum Teil schon beim Codieren erkannt:
            // int x = 1 / 0; // => Fehlermeldung: "Division durch 0"

            // Wir bleiben hartnäckig und führen Variablen ein, mit deren Hilfe wir den Compiler überlisten.
            int zahl = 1;
            int teiler = 0;
            //int divisionsErgebnis = zahl / teiler; // hier läßt der Compiler diese zeile zu, 
            // während des Programmdurchlaufes kommt es aber zu einer "DivideByZero"-Exception

            // Lösung:
            // Wir versuchen zunächst die Rechnung, fangen aber eine Exception ab
            /*
            // Variante "pur" (undifferenzierter Catch)
            try
            {
                int divisionsErgebnis = zahl / teiler;
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch
            {
                Console.WriteLine("Teilen durch 0 ???");
                // Alternativ wäre natürlich auch möglich, dass wir dann innerhalb einer Schleife eine erneute Abfrage/Rechnung vornehmen
            }
            Console.WriteLine("Nach dem catch-Block geht es dann übrigens \"ganz normal\" weiter!");
            
            // HINWEIS:
            // EGAL welcher Fehler im try-Block auftrat, wir werden im obigen Fall stets in den catch-Block springen ...
            // ... also AUCH, wenn irgend ein anderer Fehler als das teilen durch 0 geschah 
            // => Es besteht die Gefahr, dass unsere Fehlermeldung nicht zutrifft


            // **************************************************************************************************************************************
            // Differenzierte Catch:
            try
            {
                int divisionsErgebnis = zahl / teiler;
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Teilen durch 0 ist wirklich Käse");
            }
            
            // HINWEIS:
            // Die obige Vorgehensweise würde zwar vermeiden, dass wir bei einem anderen Fehler als dem Teilen durch 0
            // im catch-Block die (dann ja unpassende) Fehlermeldung "Teilen durch0???" ausgeben lassen würden ...
            // ... ABER: Falls ein anderer Fehler geschähe, dann würde unser Programm wieder abstürzen (denn es würde kein passender catch-Block gefunden)

            // Lösung
            // Wir hängen einen weiteren (undifferenzierten) catch-Block an 
            // (Hinweis: Es wird immer nur der erste zutreffende catch-Block ausgeführt)

            try
            {
                int a = Convert.ToInt32("abc"); // dieser Fehler führt zum Ausführen des undifferenzierten catch-Blockes
                //int divisionsErgebnis = zahl / teiler; // dieser Fehler führt zum Ausführen des catch-Blockes(DivideByZero)
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Teilen durch 0 ist auch beim dritten Versuch unzulässig!!!");
            }
            catch
            {
                Console.WriteLine("Irgendetwas lief hier schief!");
            }
            // Es kommt also auf die Reihenfolge an: Zuerst der undifferenzierte catch-Block und dann erst der catch(DivideByZero)-Block
            // wäre ungeschickt, da dann immer der erste ausgeführt würde, und der zweite völlig überflüssig wäre 


            // **************************************************************************************************************************************
            // Text-Ausgabe der (gefundenen) Exception:
            try
            {
                int divisionsErgebnis = zahl / teiler;
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch (Exception ausnahmeName)
            {
                Console.WriteLine("\nAusgabe: aus dem Catch-Block heraus:");
                Console.WriteLine("Inhalt von ausnahmeName: " + ausnahmeName);
            }
            
            // Man könnte nun gelegentlich den Wunsch haben, nach dem catch-Block noch mit der gefundenen Exception zu arbeiten:
            //Console.WriteLine("Inhalt von ausnahmeName: " + ausnahmeName); // Problem: ausnahmeName nur im catch-Block gültig!

            // Lösung: Wir definieren eine eigene Exception-Variable (außerhalb, bzw.) vor dem catch
            Exception meineException = null;
            try
            {
                int divisionsErgebnis = zahl / teiler;
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch (Exception ausnahmeName)
            {
                meineException = ausnahmeName; // Hier speichere ich den Wert von ausnahmeName ab, 
                                               // in einer Variable, die auch außerhalb des catch-Blockes gültig ist
            }
            Console.WriteLine("\nAusgabe: außerhalb des Catch-Blockes:");
            Console.WriteLine("Inhalt von meineException: " + meineException);
            
            // alternative Nutzung einer (eigenen) Exception-Variable
            if (meineException == null)
                Console.WriteLine("\nAlles lief fehlerfrei!");
            else
                Console.WriteLine("\nEs trat ein Fehler auf!" + meineException.Message);

            
            // ******************************************************************************************************************************
            // Kleiner Exkurs zu (vermeintlichen) Exception
            // Die ganze Technologie ist derartig komfortabel, 
            // dass man sich im Einzelfall versehentlich zu sehr auf sie verlassen könnte
            // Ein Beispiel, das zeigen soll, dass wir dennoch unsere Programme "auf Herz und Nieren" testen sollten:

            try
            {
                double wurzel = Math.Sqrt(-1);
                Console.WriteLine("\nErgebnis der Rechnung 'Wurzel von -1': " + wurzel); 
                // Ergebnis: n. def. = not defined = nicht definiert
                // ABER: keine Exception
            }
            catch
            {
                Console.WriteLine("\nKomplexe Zahlen kann ich nicht => Wurzel aus negativen Zahlen finde ich doof!!!");
            }



            Console.WriteLine();
            // *******************************************************************************************************************************
            // Finally
            try
            {
                int divisionsErgebnis = zahl / teiler; 
                // wenn wir diese Zeile auskommentieren würden, würde 138 ausgeführt und catch übersprungen
                // dennoch würde finally ausgeführt UND anschließend auch alles HINTER Finally 
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch
            {
                Console.WriteLine("Fehler!!!");
            }
            finally
            {
                Console.WriteLine("Hier sind wir im finally-Block!");
            }
            Console.WriteLine("Hier bin ich hinter dem finally-Block");

            // Frage: Wenn finally also immer ausgeführt wird (egal ob try oder catch stattfand, und "scheinbar"(!) immer alles hinter finally)
            //        dann bleibt die Frage, was soll das??

            // Antwort:
            // Falls das Programm im catch-Block beendet werden würde, dann kann im finally-Block noch etwas ausgeführt werden, 
            // was sonst nicht mehr stattfände UND in jedem Fall nach try oder catch stattfinden sollte/müsste
            // Beispiel:
            // Es wurde ein Text-Stream geöffnet, es kam zu einem Fehler, das programm soll enden, 
            // ABER der Stream noch "geclosed" werden
            // (Das closen soll aber auch am Ende geschehen, falls try klappte)

            // konkretes Beispiel:
            */
            try
            {
                int divisionsErgebnis = zahl / teiler;
                Console.WriteLine("Hier kommt das Programm nicht mehr hin ...");
            }
            catch
            {
                Console.WriteLine("\nFehler!!!!!!!!!!!!!!!");
                return; // Main wird (ohne Rückgabewert, siehe void bei Main) VERLASSEN/BEENDET
            }
            finally
            {
                Console.WriteLine("Dieser Text erscheint im finally, 'obwohl' im catch-Block das Programm bereits beendet wurde");
                Console.ReadKey();
            }
            Console.WriteLine("Hier WÄRE ich hinter dem finally-Block");
            // Hier kommen wir nicht mehr an, denn im catch wurde das programm beendet
            // also wurde nur noch finally ausgeführt und dann war Feierabend              
            /**/

            Console.ReadKey();
        }
    }
}