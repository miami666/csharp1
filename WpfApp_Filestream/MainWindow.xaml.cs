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
using System.IO;

namespace WpfApp_Filestream
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
        private void buttonRo_Click(object sender,RoutedEventArgs e)
        {

        }
        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            //UnicodeEncoding uniencoding = new UnicodeEncoding();
            //string filename = @"c:\Users\Administrator\Documents\userinputlog.txt";

            //byte[] result = uniencoding.GetBytes(UserInput.Text);

            //using (FileStream SourceStream = File.Open(filename, FileMode.OpenOrCreate))
            //{
            //    SourceStream.Seek(0, SeekOrigin.End);
            //    await SourceStream.WriteAsync(result, 0, result.Length);
            //}
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

      
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";


            Nullable<bool> result = dlg.ShowDialog();

   
            if (result == true)
            {

                string filename = dlg.FileName;
                UserInput.Text = filename;

                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(System.IO.File.ReadAllText(filename));
                FlowDocument document = new FlowDocument(paragraph);
                FlowDocReader.Document = document;
            }
        }
    }
}
