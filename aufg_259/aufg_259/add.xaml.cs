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
namespace aufg_259
{
    /// <summary>
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : Window
    {
        private readonly MainWindow _mainWindow;
        public add(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }
        private void Add_Waehrung_Button_Click(object sender, RoutedEventArgs e)
        {
            string neueW;
            double neuerUf;
            neueW = waehrung_add.Text;
            if (_mainWindow.waehrung.Contains(neueW, StringComparer.OrdinalIgnoreCase))
            {
                _mainWindow.Output_TextBox.Text = "Währung ist bereits in Ihrer Umrechnungsliste";
            }
            else
            {
                _mainWindow.waehrung.Add(neueW);
            }
            try
            {
                string s = ufaktor_add.Text;
                neuerUf = double.Parse(s);
                _mainWindow.ufaktor.Add(neuerUf);
            }
            catch(FormatException)
            {
                _mainWindow.Output_TextBox.Text = "Eingabe hat falsches Format";
            }
            _mainWindow.ClearListBox(_mainWindow.Source_ListBox);
            _mainWindow.FillListBox(_mainWindow.Source_ListBox);
            _mainWindow.ClearListBox(_mainWindow.Target_ListBox);
            _mainWindow.FillListBox(_mainWindow.Target_ListBox);
            this.Close();
        }
    }
}