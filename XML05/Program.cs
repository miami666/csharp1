using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Namespace für XML
using System.Xml;
using System.Xml.Schema;

namespace XML05
{
    class Program
    {
        static void Main(string[] args)
        {
            // XmlReaderSettings instanziieren
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            // Ggf. Einzelne Bereiche ausschliessen
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;
            // Validierungs-Typ festlegen 
            readerSettings.ValidationType = ValidationType.Schema;
            // Schema hinzufügen
            readerSettings.Schemas.Add(null, @"..\..\Personen.xsd");
            // EventHandler mit Callback ergänzen
            readerSettings.ValidationEventHandler += ValidationCallback;
            // Aufruf Reader inkl. Validierung


            // Daten aus einer XML-Datei werden in den XmlReader eingelesen
            // Ergänzt durch settings, die auch validieren ermöglichen
            XmlReader reader = XmlReader.Create(@"..\..\Personen.xml", readerSettings);
            // reader bis zum ende lesen
            // try in erster Linie um Validierung abzufangen
            try
            {
                while (reader.Read())
                {
                    // In der Schleife werden die einzelnen Knoten gelesen und 
                    // geprüft werden
                    /*
                     * Eigenschaft NodeType, beschrieben durch Enumeration XmlNodeType
                     * Element
                     * Attibute 
                     * Text
                     * CDATA    beschreibt CDATA Abschnitt
                     * ProcessingInstruction    PI, <?pi Testanweisung?>
                     * Comment
                     * Whitespace
                     * EndElement
                     * XmlDeclaration 
                     * 
                     */
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.XmlDeclaration:
                            // Eigenschaft value liefert den Inhalt
                            Console.WriteLine("{0,-20}<{1}>", "Deklaration", reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.WriteLine("{0,-20}<!--{1}-->", "Kommentar", reader.Value);
                            break;
                        case XmlNodeType.Whitespace:
                            Console.WriteLine("{0,-20}", "Whitespace");
                            break;
                        case XmlNodeType.Element:
                            if (reader.IsEmptyElement)
                                // Elemente können mit der Eigenschaft Name ausgewertet werden
                                Console.WriteLine("{0,-20}<{1}/>", "Leeres Element", reader.Name);
                            else
                            {
                                Console.WriteLine("{0,-20}<{1}>", "Element", reader.Name);
                                //Console.WriteLine("{0,-20}<{1}>", "Element", reader.Value);
                                // Prüfen, ob Attribute vorliegen
                                if (reader.HasAttributes)
                                {
                                    // Attribute durchlaufen
                                    while (reader.MoveToNextAttribute())
                                    {
                                        Console.WriteLine("{0,-20}{1}", "Attribut", reader.Name + " = " + reader.Value);
                                    }
                                }
                            }
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine("{0,-20}</{1}>", "End_Element", reader.Name);
                            break;
                        // Zeigt die textlichen Inhalte der jeweiligen Tags
                        case XmlNodeType.Text:
                            Console.WriteLine("{0,-20}{1}", "Text", reader.Value);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Validierung fehlgeschlagen.\n{0}", ex.Message);
            }
            Console.ReadLine();
        }
        // Callback Methode für EventHandler bei Validierungsfehler

        static void ValidationCallback(object sender, ValidationEventArgs e)
        {
            //throw e.Exception;
            Console.WriteLine(e.Message);
        }
    }
}