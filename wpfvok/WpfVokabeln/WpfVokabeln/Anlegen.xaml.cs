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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfVokabeln
{
    /// <summary>
    /// Interaction logic for Anlegen.xaml
    /// </summary>
    public partial class Anlegen : Window
    {
        MySqlConnection conn;
        public Anlegen(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string deutsch = TbDe.Text;
                string spanisch = TbEs.Text;
                string englisch = TbGb.Text;
                string strSQL = "Insert INTO vokabeln(deutsch, spanisch, englisch) VALUES(@de,@es,@gb)";
                MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("@de", deutsch);
                cmd.Parameters.AddWithValue("@es", spanisch);
                cmd.Parameters.AddWithValue("@gb", englisch);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Satz angelegt");
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
