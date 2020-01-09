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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfApp_Editor
{
    /// <summary>
    /// Interaction logic for anzeige.xaml
    /// </summary>
    public partial class anzeige : Window
    {
        private readonly RichTextEditorBeispiel _rich;
        public anzeige(RichTextEditorBeispiel rich)
        {
            _rich = rich;
            InitializeComponent();

            string filename;
            filename = _rich.UserInput.Text;
            var flowDocument = new FlowDocument();
                var textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
            if(File.Exists(filename))
            {
                using (FileStream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    textRange.Load(fileStream, DataFormats.Rtf);
                }
                FlowDocReader.Document = flowDocument;
            }
            else
            {
                MessageBox.Show("keine Datei ausgewählt");
            }


        }
    }
}
