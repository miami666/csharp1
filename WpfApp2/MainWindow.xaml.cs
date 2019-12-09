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

namespace WpfApp2
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
            Clipboard.SetText(textBox1.Text); //set text to clipBoard
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();//get text from clipBoard
        }
    }
}
