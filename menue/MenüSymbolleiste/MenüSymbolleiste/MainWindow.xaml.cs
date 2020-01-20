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

namespace MenüSymbolleiste
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

        private void sichtbar_tb1(object sender, RoutedEventArgs e)
        {
            sichtbar(item_tb1, tb1);
        }

        private void sichtbar_tb2(object sender, RoutedEventArgs e)
        {
            sichtbar(item_tb2, tb2);
        }

        private void sichtbar(MenuItem mi, ToolBar tb)
        {
            if (mi.IsChecked)
                tb.Visibility = Visibility.Visible;
            else
                tb.Visibility = Visibility.Collapsed;
        }

        private void gesperrt(object sender, RoutedEventArgs e)
        {
            tbtray.IsLocked = (bool)cb.IsChecked; 
        }
    }
}
