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
using MaterialDesignThemes.Wpf;

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
            //cld.SelectedDate = DateTime.Now;
            
            TxtDateiParse();
            neueSpeise.Content = new PackIcon { Kind = PackIconKind.FoodForkDrink,
                FontSize = 40,
                Width = 36,
                Height = 36
            };
            btnCalc.Content = new PackIcon
            {
                Kind = PackIconKind.CalculatorVariant,
                FontSize = 40,
                Width = 36,
                Height = 36
            };
            btnAdd.Content = new PackIcon
            {
                Kind = PackIconKind.Cannabis,
                FontSize = 40,
                Width = 36,
                Height = 36
            };

        }
        double kcal;
        string inp;
  
        double sum;
        bool abDafuer=false;
        Dictionary<string, double> kcalDict = new Dictionary<string, double>();


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string filename = String.Format(@"{0:yyyy-MM-dd}.txt", DateTime.Now);

            if (kcalValue.Text != "" && speiseKey.Text != "")
            {
               inp = speiseKey.Text;
               if (!Double.TryParse(kcalValue.Text, out kcal))
                {
                    MessageBox.Show("Bitte eine Zahl eingeben");
                }
               else
                {
                    if (File.Exists(filename))
                    {
                        var content = System.IO.File.ReadAllText(filename);
                        if (content.Contains(speiseKey.Text))
                        {
                            MessageBox.Show("Key existiert schon");
                        }
                        else
                        {
                            kcalDict.Add(inp, kcal);
                            WriteDictToFile(kcalDict, filename);
                        }
                    }
                    else
                    {
                        kcalDict.Add(inp, kcal);
                        WriteDictToFile(kcalDict, filename);
                    }
                        
                        
                    
                }
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
            using (StreamWriter fileWriter = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, double> kvPair in Dict)
                {
                    fileWriter.WriteLine("{0},{1}", kvPair.Key, kvPair.Value);
                }
            }
        }
        private void TxtDateiParse()
        {
            string filename = String.Format(@"{0:yyyy-MM-dd}.txt", DateTime.Now);
            //wenn Datei mit heutigem Datum schon besteht, schon eingetragene Key Value Paare parsen und dem Dictionary hinzufügen
            if (File.Exists(filename))
            { // erstellen eines string[][] arrays das in der ersten Dimension den Key und in der zweiten Dimension den dementsprechenden Value enthält
                MessageBox.Show("Kalorien Tagebuch für den heutigen Tag existiert bereits. Werte werden eingelesen");
                var lines = File.ReadAllLines(filename)
                .Select(s => s.Split(','))
                .ToArray();
               
                // durchs array loopen  und key/value paare zum dictionary hinzufügen
                for (int i = 0; i < lines.Length; i++)
                {
                    // z.B. lines[i][0] = Eis, lines[i][1] = 1000
                    kcalDict[lines[i][0]] = Convert.ToDouble(lines[i][1]);
                }
                // Testausgabe zur Überprüfung
                foreach (KeyValuePair<string, double> entry in kcalDict)
                {
                    MessageBox.Show(entry.Key + "," + entry.Value);
                }
            }
            else
            {
               // MessageBox.Show("Kalorientagebuch für den heutigen Tag noch leer.");               
            }
        }
        
    }
}
