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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            
        }
        void OnClick1(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.White;
            btn2.Background = Brushes.Pink;
            btn3.Background = Brushes.Blue;
            
        }

        void OnClick2(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.Pink;
            btn2.Background = Brushes.White;
            btn3.Background = Brushes.Blue;
          
        }

        void OnClick3(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.Pink;
            btn2.Background = Brushes.Blue;
            btn3.Background = Brushes.White;
           
            string s = (sender as Button).Name.ToString();
            
        }
       
    }
}
