using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace XML02
{
    class Person
    {
        public string Vorname { get; set; }
        public string Zuname { get; set; }
        public int Alter { get; set; }
        public Adresse Adresse { get; set; }

    }
    class Adresse
    {
        public string Ort { get; set; }
        public string Strasse { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> liste = new List<Person>();
            Person person = null;
            using (XmlReader reader = XmlReader.Create(@"..\..\personen.xml"))
            {
                while (reader.Read())
                {
                    if(reader.NodeType==XmlNodeType.Element)
                    {
                        switch(reader.Name)
                        {
                            case "Person":
                                person = new Person();
                                liste.Add(person);
                                break;
                            case "Vorname":
                                person.Vorname = reader.ReadString();
                                break;
                            case "Zuname":
                                person.Zuname = reader.ReadString();
                                break;
                            case "Alter":
                                person.Alter = reader.ReadElementContentAsInt();
                                break;
                            case "Adresse":
                                Adresse adresse = new Adresse();
                                person.Adresse = adresse;
                                if(reader.HasAttributes)
                                {
                                    while(reader.MoveToNextAttribute())
                                    {
                                        if(reader.Name=="Ort")
                                        {
                                            adresse.Ort = reader.Value;
                                        }
                                        else if(reader.Name=="Strasse")
                                        {
                                            adresse.Strasse = reader.Value;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    
                }
               

            }
            GetList(liste);
            XmlDocument doc = new XmlDocument();
            doc.Load("product.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Store/Product");
            string product_id = "", product_name = "", product_price = "";
            foreach (XmlNode node in nodes)
            {
                product_id = node.SelectSingleNode("Product_id").InnerText;
                product_name = node.SelectSingleNode("Product_name").InnerText;
                product_price = node.SelectSingleNode("Product_price").InnerText;
                Console.WriteLine(product_id + " " + product_name + " " + product_price);
            }
            Console.ReadKey();
            

        }
        static void GetList(List<Person> liste)
        {
            foreach (Person item in liste)
            {
                Console.WriteLine("Vorname: {0}\nZuname: {1}\nAlter: {2}",item.Vorname,item.Zuname,item.Alter);
                Console.WriteLine("Ort: {0}\nStrasse: {1}", item.Adresse.Ort, item.Adresse.Strasse );


            }

        }
    }
}
