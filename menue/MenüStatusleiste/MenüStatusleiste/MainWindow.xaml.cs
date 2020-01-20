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

namespace MenüStatusleiste
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb1.Text = DateTime.Today.ToShortDateString();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tb2.Text = (int)Width + "*" + (int)Height;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            tb3.Text = "X:" + (int)e.GetPosition(this).X
                + " Y:" + (int)e.GetPosition(this).Y;
        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb.IsChecked)
                wp.Visibility = Visibility.Visible;
            else
                wp.Visibility = Visibility.Collapsed;
        }
    }
}
