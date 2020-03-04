using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace WpfVokabeln
{
    [Serializable]
    public class Vokabeltest
    {
        public string TbFrage;
        public string TbAntwort;
        public Vokabeltest() {
        }
        public Vokabeltest(string frage, string antwort)
        {
            TbFrage = frage;
            TbAntwort = antwort;
        }
    } 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static FileStream stream;
        private MySqlConnection conn;
        ArrayList frage = new ArrayList();
        ArrayList antwort = new ArrayList();
        Random r = new Random();
        int zufall = 0;
        string dateif = "de";
        string dateia = "es";
        int durch = 0;
        int max = 0;
        Vokabeltest vt = new Vokabeltest();

        public MainWindow()
        {
            InitializeComponent();
            Db db = new Db();
            conn = db.verbind();
        }




        private void weiter()
        {
            if (frage.Count < 1)
            {
                MessageBox.Show(
                    "Gratuliere! Alles geschafft");
                frage.Clear();
                antwort.Clear();
                Close();
                // Ende markieren fehlt
            }

            /* Falls noch Vokabeln in der Liste: Nächste */
            else
            {

                zufall = r.Next(0, frage.Count);
                TbFrage.Text = "" + frage[zufall];
                TbAntwort.Text = "";
            }

        }

        private void BtOk_Click(object sender, RoutedEventArgs e)
        {
            durch++;
            if (TbAntwort.Text == (string)antwort[zufall])
            {
                MessageBox.Show("Richtig", "Vokabel");
               // frage.RemoveAt(zufall);
               // antwort.RemoveAt(zufall);


            }
            else
                MessageBox.Show("Falsch, richtige Antwort" +
                    " ist\n'" + antwort[zufall] +
                    "'", "Vokabel");
            weiter();
            if (zufall > 0)
                TbFrage.Text = "" + frage[zufall];

            TbAntwort.Focus();
            LbErg.Content = "Versuch " + durch + " von " + max;
        }

        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string strSQL = "SELECT * FROM vokabeln";
                MySqlCommand cmd = new MySqlCommand(strSQL, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (dateif == "de")
                        frage.Add(reader["deutsch"]);
                    else if (dateif == "es")
                        frage.Add(reader["spanisch"]);
                    else
                        frage.Add(reader["englisch"]);

                    if (dateia == "de")
                        antwort.Add(reader["deutsch"]);
                    else if (dateia == "es")
                        antwort.Add(reader["spanisch"]);
                    else
                        antwort.Add(reader["englisch"]);
                }
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            max = frage.Count;
            weiter();
            TbFrage.Text = frage[zufall].ToString();
            TbAntwort.Focus();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {

                if ((cbfrage.SelectedItem as ComboBoxItem).Content.ToString() == "deutsch")
                    dateif = "de";
                if ((cbfrage.SelectedItem as ComboBoxItem).Content.ToString() == "spanisch")
                    dateif = "es";
                if ((cbfrage.SelectedItem as ComboBoxItem).Content.ToString() == "englisch")
                    dateif = "gb";
                if ((cbantwort.SelectedItem as ComboBoxItem).Content.ToString() == "deutsch")
                    dateia = "de";
                if ((cbantwort.SelectedItem as ComboBoxItem).Content.ToString() == "spanisch")
                    dateia = "es";
                if ((cbantwort.SelectedItem as ComboBoxItem).Content.ToString() == "englisch")
                    dateia = "gb";

            }
        }

        private void BtHin_Click(object sender, RoutedEventArgs e)
        {
            Anlegen win = new Anlegen(conn);
            win.Show();
        }

        private void serialize_Click(object sender, RoutedEventArgs e)
        {
            Vokabeltest vt = new Vokabeltest(TbFrage.Text, TbAntwort.Text)
            {
                TbFrage = TbFrage.Text,
                TbAntwort = (string)antwort[zufall]

            };
            
            /*          IFormatter formatter = new BinaryFormatter();
                      string path2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "vokabeltest.bin");
                      stream = new FileStream(path2, FileMode.Create, FileAccess.Write, FileShare.None);
                      formatter.Serialize(stream, vt);*/

            XmlSerializer xml_serializer =
        new XmlSerializer(typeof(Vokabeltest));
            /*        using (StringWriter string_writer = new StringWriter())
                    {
                        // Serialize.
                        xml_serializer.Serialize(string_writer, vt);
                        tbserialize.Text = string_writer.ToString();
                    }*/
            string path2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "vokabeltest.xml");
            using (TextWriter txtwriter = new StreamWriter(path2))
            {
                xml_serializer.Serialize(txtwriter, vt);

            }
        }
        private void deserialize_Click(object sender, RoutedEventArgs e)
        {
            /*            string path2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "vokabeltest.bin");
                        Stream stream = new FileStream(path2, FileMode.Open);
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Deserialize(stream);*/


            XmlSerializer deserializer = new XmlSerializer(typeof(Vokabeltest));
            string path2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "vokabeltest.xml");
            using (TextReader reader = new StreamReader(path2))
            {

                object obj = deserializer.Deserialize(reader);
                Vokabeltest XmlData = (Vokabeltest)obj;
                TbFrage.Text = XmlData.TbFrage;

                TbAntwort.Text = XmlData.TbAntwort;
                string sql = "Select * from vokabeln where deutsch=@param";
                MySqlCommand select = new MySqlCommand(sql, conn);
                select.Parameters.AddWithValue("@param", TbFrage.Text);
                MySqlDataReader mysqlreader = select.ExecuteReader();
                mysqlreader.Close();

            }
            



        }
            
    }

}
