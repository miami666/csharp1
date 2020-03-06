using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XML06
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlWriteSettings
            XmlWriterSettings settings = new XmlWriterSettings();
            //einrückung nodes
            settings.Indent = true;
            settings.IndentChars = "  ";
            string filename = "personen.xml";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (XmlWriter w = XmlWriter.Create(Path.Combine(path,filename),settings)) {

                w.WriteStartDocument();
                w.WriteStartElement("Personen");
                w.WriteComment("auto generated");
                w.WriteStartElement("Person");
                w.WriteElementString("Zuname", "Lorbas");
                w.WriteElementString("Vorname", "L");
                w.WriteStartElement("Adresse");
                w.WriteAttributeString("Ort", "Koeln");
                w.WriteAttributeString("strasse", "schlossallee");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndElement();

            }
        
        }
    }
}
