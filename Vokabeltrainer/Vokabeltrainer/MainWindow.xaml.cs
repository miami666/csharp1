using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Diagnostics;
namespace Vokabeltrainer
{
    class DBConnect
    {
        static string myConnectionstring = "server=localhost;uid=root;password=;database=vokabeltrainer;";
        MySqlConnection con = new MySqlConnection(myConnectionstring);
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        public DBConnect()
        {
           // Initialize();
        }
      /*  private void Initialize()
        {
            server = "localhost";
            database = "mitarbeiter";
            uid = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=";
            connection = new MySqlConnection(connectionString);
        }*/
        public MySqlConnection verbind()
        {
            try
            {
                con.Open();
                MessageBox.Show("Verbindung hergestellt");
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Kann keine Verbindung zum Datenbank Server erstellen");
                        break;
                    case 1045:
                        MessageBox.Show("Benutzername und oder passwort ungültig");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                con = null;
            }
            return con;
        }
/*
        public void ReadData(MySqlConnection con)
        {
            var items = new List<Vokabeln>();
            using (con)
            {
                var command = new MySqlCommand("", con);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new Vokabeln()
                        {
                            Id = Convert.ToInt32(dr[0]),
                            Deutsch = Convert.ToString(dr[1]),
                            Englisch = Convert.ToString(dr[2])
                        };
                        items.Add(item);
                    };
                };
            };
        }*/
        public string createVkbl(MySqlConnection con, string de,string en)
        {
            var stringToReturn = "";

            try
            {
                using (con)
                {
               

                    //Compose query using sql parameters
                    var sqlCommand = "INSERT INTO vokabeln (deutsch,englisch) VALUES (@de,@en)";

                    //Create mysql command and pass sql query
                    using (var command = new MySqlCommand(sqlCommand, con))
                    {
                        command.Parameters.AddWithValue("@de", de);
                        command.Parameters.AddWithValue("@en", en);
                        command.ExecuteNonQuery();
                    }

                    stringToReturn = "Erfolg.Hurra!";
                }
            }
            catch (MySqlException ex)
            {
                stringToReturn = "Fehler: " + ex.Message;
            }

            return stringToReturn;
        }
    }
    public partial class MainWindow : Window
    {
        Vokabeln aktuelleVokabel;
        Random random = new Random();
        List<Vokabeln> items = new List<Vokabeln>();
        public MainWindow()
        {
            InitializeComponent();
            DBConnect db = new DBConnect();
            MySqlConnection dbcon = db.verbind();
            // db.ReadData(dbcon);
            using (dbcon)
            {
                var command = new MySqlCommand("select * from vokabeln", dbcon);
                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new Vokabeln()
                        {
                            Id = Convert.ToInt32(dr[0]),
                            Deutsch = Convert.ToString(dr[1]),
                            Englisch = Convert.ToString(dr[2])
                        };
                        items.Add(item);
                    };
                };
            };
            lvVokabeln.ItemsSource = items;
            aktuelleVokabel = items[random.Next(items.Count)];
            labelAbfrage.Content = aktuelleVokabel.HoleDeutschesWort();
        }
        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            if (aktuelleVokabel.Prüfe(textBoxEingabe.Text))
            {
                int iMax = -1;
                double fq = 0.0;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].WarEineMinuteNichtDran())
                    {
                        double fqi = items[i].BerechneFehlerquotient();
                        if (fqi > fq)
                        {
                            fq = fqi;
                            iMax = i;
                        }
                    }
                }
                if (iMax == -1)
                {
                    iMax = random.Next(items.Count);
                }
                aktuelleVokabel = items[iMax];
                labelAbfrage.Content = aktuelleVokabel.HoleDeutschesWort();
                textBoxEingabe.Clear();
                meinBlock.Text="Richtig!";
                meinBlock.Foreground = Brushes.Green;
                Debug.WriteLine(Vokabeln.LetzteAbfrage);
                Debug.WriteLine(aktuelleVokabel.WarEineMinuteNichtDran());

                //MessageBox.Show("Richtig!");
            }
            else
            {
                //MessageBox.Show("Leider falsch!");
                textBoxEingabe.Clear();
                meinBlock.Text = "Falsch!";
                meinBlock.Foreground = Brushes.Red;
            }
        }
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            DBConnect db = new DBConnect();
            MySqlConnection connekke = db.verbind();
           
            Debug.WriteLine(db.createVkbl(connekke, insertDe.Text, insertEn.Text));

        }
     
    }
    class Vokabeln
    {
        int id;
        string deutsch;
        string englisch;
        public int Id { get; set; }
        public string Deutsch { get; set; }
        public string Englisch { get; set; }
        public override string ToString()
        {
            return this.Id + " " + this.Deutsch + " " + this.Englisch;
        }
        string deutschesWort;
        public string HoleDeutschesWort()
        {
            return Deutsch;
        }
        string englischeÜbersetzung;
        public string HoleEnglischesWort()
        {
            return Englisch;
        }
        DateTime letzteAbfrage;
        int zahlKorrekterAbfragen;
        int zahlFehlgeschlagenerAbfragen;
        public static DateTime LetzteAbfrage
        {
            get;
            set;
        }
        public static int ZahlKorrekterAbfragen { get; set; }
        public int ZahlFehlgeschlagenerAbfragen { get; set; }
        public bool WarEineMinuteNichtDran()
        {
            return letzteAbfrage < DateTime.Now - TimeSpan.FromMinutes(1);
        }
        public double BerechneFehlerquotient()
        {
            if (zahlKorrekterAbfragen + zahlFehlgeschlagenerAbfragen == 0)
            {
                return 0.5;
            }
            return (double)zahlFehlgeschlagenerAbfragen / (zahlKorrekterAbfragen + zahlFehlgeschlagenerAbfragen);
        }
        public Vokabeln()
        {
        }
        public Vokabeln(string deutschesWort, string englischeÜbersetzung)
        {
            this.Deutsch = deutschesWort;
            this.Englisch = englischeÜbersetzung;
            letzteAbfrage = DateTime.Now;
        }
        public bool Prüfe(string p)
        {
            letzteAbfrage = DateTime.Now;
            if (p == HoleEnglischesWort())
            {
                zahlKorrekterAbfragen++;
                return true;
            }
            else
            {
                zahlFehlgeschlagenerAbfragen++;
                return false;
            }
        }
    }
}
