using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfRtf
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

        private void dspeichern_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }

        }

        private void dladen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All Files(*.*)|*.*";
            if(dlg.ShowDialog()==true)
            {
                string filename = dlg.FileName;
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                range.Load(filestream, DataFormats.Rtf);
                filestream.Close();
            }

        }

        private void aspeichern_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                Paragraph p = fd.Blocks.ElementAt(0) as Paragraph;
                TextRange range = new TextRange(p.ContentStart, p.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }

        }

        private void aladen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
