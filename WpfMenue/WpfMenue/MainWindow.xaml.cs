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

namespace WpfMenue
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

        private void Cb_groesse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IsLoaded && (sender as ComboBox).SelectedIndex != -1)
            {
                lb.FontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as ComboBoxItem).Content);
                cb_groesse01.SelectedIndex = (sender as ComboBox).SelectedIndex;
                cb_groesse.SelectedIndex = (sender as ComboBox).SelectedIndex;
            }
        }

        private void Item_fett_Click(object sender, RoutedEventArgs e)
        {

            if ((sender as MenuItem).IsChecked )
            { 
                lb.FontWeight = FontWeights.Bold;
                item_fett.IsChecked = true;
                item_fett_kontextmenu.IsChecked = true;
                Tg01.IsChecked = true;
            }
            else
            { 
                lb.FontWeight = FontWeights.Normal;
                item_fett.IsChecked = false;
                item_fett_kontextmenu.IsChecked = false;
                Tg01.IsChecked = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lb.Content = tb.Text;
            if (lb.Content.ToString() == "")
                lb.Content = "(leer)";
        }

        private void MEnde_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                string s = (e.Source as RadioButton).Content.ToString();
                switch (s)
                {
                    case "Weiß":
                        lb.Background = Brushes.White;
                        break;
                    case "Gelb":
                        lb.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case "Rot":
                        lb.Background = new SolidColorBrush(Colors.Red);
                        break;
                }
            }
        }

        private void Cm_Opened(object sender, RoutedEventArgs e)
        {

        }

        private void Cm_Closed(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Tg01.IsChecked == true)
            { 
                lb.FontWeight = FontWeights.Bold;
                item_fett.IsChecked = true;
                item_fett_kontextmenu.IsChecked = true;
            }
            else
            {
                lb.FontWeight = FontWeights.Normal;
                item_fett.IsChecked = false;
                item_fett_kontextmenu.IsChecked = false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb3.Text = DateTime.Today.ToShortDateString();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tb4.Text = (int)Width + "*" + (int)Height;

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            tb5.Text = "X: " + (int)e.GetPosition(this).X + " Y: " + (int)e.GetPosition(this).Y;

        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            if((bool)cb.IsChecked)
            {
                wp.Visibility = Visibility.Visible;
            }
            else
            {
                wp.Visibility = Visibility.Collapsed;
            }

        }
    }
}
