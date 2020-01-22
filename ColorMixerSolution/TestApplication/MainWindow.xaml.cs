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

namespace TestApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            colorMixer.Color = Colors.Black;
        }

        private void cmdGetColor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(colorMixer.Color.ToString(), "Farbwert");
        }

        private void cmdSet_Click(object sender, RoutedEventArgs e)
        {
            colorMixer.Color = Colors.Black;
        }

        private void colorMixer_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (lblColor != null) lblColor.Text = "The new color is " + e.NewValue.ToString();
        }

    }
}
