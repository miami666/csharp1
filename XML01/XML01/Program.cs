using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XML01
{
 
    class Program
    {
        private const string FILE_NAME = "personen.xml";
        static void Main(string[] args)
        {
         
            async Task TestReader(System.IO.Stream stream)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Async = true;

                using (XmlReader readerasync = XmlReader.Create(stream, settings))
                {
                    while (await readerasync.ReadAsync())
                    {
                        switch (readerasync.NodeType)
                        {
                            case XmlNodeType.XmlDeclaration:
                                Console.Write("<?xml version='1.0'?>");
                                break;
                            case XmlNodeType.Element:
                                Console.WriteLine("Start Element {0}", readerasync.Name);
                                break;
                            case XmlNodeType.Text:
                                Console.WriteLine("Text Node: {0}",
                                         await readerasync.GetValueAsync());
                                break;
                            case XmlNodeType.EndElement:
                                Console.WriteLine("End Element {0}", readerasync.Name);
                                break;
                            default:
                                Console.WriteLine("Other node {0} with value {1}",
                                                readerasync.NodeType, readerasync.Value);
                                break;
                        }
                    }
                }
            }
            System.IO.Stream f = new FileStream(FILE_NAME, FileMode.Open,
            FileAccess.Read, FileShare.Read);
            TestReader(f).Wait();

/*            XmlReader reader = XmlReader.Create(@"..\..\Personen.xml");
            while(reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        break;

                }
              
            }*/
            Console.ReadKey();
        }
    }
}
