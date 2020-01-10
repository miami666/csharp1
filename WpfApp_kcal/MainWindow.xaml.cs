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
namespace WpfApp_kcal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  

public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //List<Dictionary<string, string>> y = new List<Dictionary<string, string>>();


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddKeyValue(txtKey.Text, txtStringValue.Text);
        }
        private void AddKeyValue(object key, object value)
        {
            // load the resource dictionary
            var rd = new System.Windows.ResourceDictionary();
            rd.Source = new System.Uri("pack://application:,,,/Dic.xaml", System.UriKind.RelativeOrAbsolute);

            // add the new key with value
            rd.Add(key, value);
            if (rd.Contains(key))
            {
                rd[key] = value;
            }
            else
            {
                rd.Add(key, value);
            }

            // now you can save the changed resource dictionary
            var settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            var writer = System.Xml.XmlWriter.Create(@"Dic.xaml", settings);
            System.Windows.Markup.XamlWriter.Save(rd, writer);
        }



    }
        
    }

