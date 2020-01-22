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

namespace WpfFlow02
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N)
            {
                Paragraph p = fd.Blocks.ElementAt(0) as Paragraph;
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new Run("normal "));
                p.Inlines.Add(new Bold(new Run("fett ")));

                Span sp = new Span(new Run("tief,Größe 12"));
                sp.BaselineAlignment = BaselineAlignment.Subscript;
                sp.FontSize = 12;
                p.Inlines.Add(sp);
            }
            else if (e.Key == Key.A)
            {
                Paragraph p = fd.Blocks.ElementAt(0) as Paragraph;
                Bold Bo = p.Inlines.ElementAt(7) as Bold;
                Underline un = Bo.Inlines.ElementAt(0) as Underline;
                Italic it = un.Inlines.ElementAt(0) as Italic;
                Run r = it.Inlines.ElementAt(0) as Run;
                r.Text = "Fku";
                InlineUIContainer ic = p.Inlines.ElementAt(16) as InlineUIContainer;
                Button bu = ic.Child as Button;
                bu.Content = "Click";
            }
            else if (e.Key == Key.S)
            {
                Paragraph p = fd.Blocks.ElementAt(0) as Paragraph;
                string ausgabe = "";
                for (int i = 0; i < p.Inlines.Count; i++)
                {
                    Inline inl = p.Inlines.ElementAt(i) as Inline;
                    ausgabe += i + ": " + inl.GetType().ToString() + "|" + runtext(inl) + "|\n";
                }
                MessageBox.Show(ausgabe);

             }
          }
        private string runtext(Inline i)
        {
            if (i is Run)
                return (i as Run).Text;
            else if (i is Bold)
                return runtext((i as Bold).Inlines.ElementAt(0));
            else if (i is Italic)
                return runtext((i as Italic).Inlines.ElementAt(0));
            else if (i is Underline)
                return runtext((i as Underline).Inlines.ElementAt(0));
            else if (i is Span)
                return runtext((i as Span).Inlines.ElementAt(0));
            else
                return "";
        }




    }
       
 }

