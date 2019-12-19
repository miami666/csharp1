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

//Using namespaces 
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DataGridBind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MySqlConnection Connection
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringMitarbeiter"].ConnectionString);      
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion
        #region bind data to DataGrid.
        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select id,vorname,nachname,plz,ort,strasse,abteilung from mitarbeiter", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dataGridMitarbeiter.DataContext = ds;
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion



    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
                ///the following statement
                ///inserts
                ///updates
                ///deletes for you
                /// Without the SqlCommandBuilder, this line would fail.
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from mitarbeiter", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                adp.Update(ds,"LoadDataBinding");
                dataGridMitarbeiter.DataContext = ds;
                
            }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
            finally
            {
                conn.Close();
            }
    }


}
  
}

