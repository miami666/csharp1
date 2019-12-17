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

namespace WpfApp3
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
        private void Btn1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textbox01.Text); //set text to clipBoard
            textbox01.Text = "In Zwischenablage Kopiert";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            textbox02.Text = Clipboard.GetText();//get text from clipBoard
        }
    }
}
