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

namespace MenüKontext
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

        private void menu_fett(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).IsChecked)
            {
                lb1.FontWeight = FontWeights.Bold;
                item_fett_hauptmenu.IsChecked = true;
                item_fett_kontextmenu.IsChecked = true;
            }
            else
            {
                lb1.FontWeight = FontWeights.Normal;
                item_fett_hauptmenu.IsChecked = false;
                item_fett_kontextmenu.IsChecked = false;
            }
        }

        private void status(object sender, RoutedEventArgs e)
        {
            if(cm.IsOpen)
                lb2.Content = "Kontextmenü geöffnet";
            else
                lb2.Content = "Kontextmenü geschlossen";
        }
    }
}
