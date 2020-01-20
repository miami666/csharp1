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

namespace MenüHaupt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menu_kopieren(object sender, RoutedEventArgs e)
        {
            lb.Content = tb.Text;
            if (lb.Content.ToString() == "") lb.Content = "(leer)";
        }

        private void menu_ende(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menu_hintergrund(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                string s = (e.Source as RadioButton).Content.ToString();
                switch (s)
                {
                    case "Weiß": lb.Background = new SolidColorBrush(Colors.White); break;
                    case "Gelb": lb.Background = new SolidColorBrush(Colors.Yellow); break;
                    case "Rot": lb.Background = new SolidColorBrush(Colors.Red); break;
                }
            }
        }

        private void menu_cb_groesse(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded && cb_groesse.SelectedIndex != -1)
                lb.FontSize = Convert.ToDouble((cb_groesse.SelectedItem as ComboBoxItem).Content);
        }

        private void menu_fett(object sender, RoutedEventArgs e)
        {
            if (item_fett.IsChecked)
                lb.FontWeight = FontWeights.Bold;
            else
                lb.FontWeight = FontWeights.Normal;
        }
    }
}
