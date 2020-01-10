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
using Microsoft.Win32;
using System.Diagnostics;

namespace Wpf_kcal_calc
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
        double kcal;
        string inp;
        double sum;
        bool abDafuer=false;
        Dictionary<string, double> kcalDict = new Dictionary<string, double>();



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(kcalValue.Text != "" && speiseKey.Text != "")
            {
                inp = speiseKey.Text;
                Double.TryParse(kcalValue.Text, out kcal);
                kcalDict.Add(inp, kcal);
                string filename = String.Format("C:\\{0:yyyy-MM-dd}.txt", DateTime.Now);
                
                WriteDictToFile(kcalDict, filename);

            }
           
           
        }
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            abDafuer = true;
           
            double sum = kcalDict.Sum(x => x.Value);
            MessageBox.Show("Da pack ich mir an de Kopp. Du has janz fiese " + sum + " Kalorien jefräße.\nDu mus " + 30 * sum / 50 + " Minuten die Beene vertredde john oder + " + 60 * sum / 400 + " Minuten schwemme.");
           

        }
        private void btnNeueSpeise_Click(object sender, RoutedEventArgs e)
        {
            speiseKey.Clear();
            kcalValue.Clear();

        }
        private void WriteDictToFile(Dictionary<string, double> Dict, string path)
        {
         
            using (StreamWriter fileWriter = new StreamWriter(path,true))
            {
           
                foreach (KeyValuePair<string, double> kvPair in Dict)
                {
                    fileWriter.WriteLine("{0}: {1}", kvPair.Key, kvPair.Value);
                }
            }
        
        }
    }
}

