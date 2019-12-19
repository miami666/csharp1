using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
    public partial class MainWindow : Window
    {
        Vokabel[] vokabular = new Vokabel[3];
        Vokabel aktuelleVokabel;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            vokabular[0] = new Vokabel("hallo", "hello");
            vokabular[1] = new Vokabel("gehen", "to go");
            vokabular[2] = new Vokabel("gut", "good");

            aktuelleVokabel = vokabular[random.Next(vokabular.Length)];
            labelAbfrage.Content = aktuelleVokabel.HoleDeutschesWort();
        }

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            if (aktuelleVokabel.Prüfe(textBoxEingabe.Text))
            {
                int iMax = -1;
                double fq = 0.0;
                for (int i = 0; i < vokabular.Length; i++)
			    {
			        if(vokabular[i].WarEineMinuteNichtDran())
                    {
                        double fqi = vokabular[i].BerechneFehlerquotient();
                        if(fqi > fq)
                        {
                            fq = fqi;
                            iMax = i;
                        }
                    }
			    }
                if (iMax == -1)
                {
                    iMax = random.Next(vokabular.Length);
                }
                aktuelleVokabel = vokabular[iMax];
                labelAbfrage.Content = aktuelleVokabel.HoleDeutschesWort();
                textBoxEingabe.Clear(); // nach Videoaufnahme ergänzt
            }
            else
            {
                MessageBox.Show("Leider falsch!");
            }
        }
    }

    class Vokabel
    {
        string deutschesWort;
        public string HoleDeutschesWort()
        {
            return deutschesWort;
        }
        string englischeÜbersetzung;
        DateTime letzteAbfrage;
        int zahlKorrekterAbfragen;
        int zahlFehlgeschlagenerAbfragen;

        public bool WarEineMinuteNichtDran()
        {
            return letzteAbfrage < DateTime.Now - TimeSpan.FromMinutes(1);
        }

        public double BerechneFehlerquotient()
        {
            if (zahlKorrekterAbfragen + zahlFehlgeschlagenerAbfragen == 0)
            {
                return 0.5;
            }
            return (double)zahlFehlgeschlagenerAbfragen / (zahlKorrekterAbfragen + zahlFehlgeschlagenerAbfragen);
        }

        public Vokabel(string deutschesWort, string englischeÜbersetzung)
        {
            this.deutschesWort = deutschesWort;
            this.englischeÜbersetzung = englischeÜbersetzung;
            letzteAbfrage = DateTime.Now;
        }

        public bool Prüfe(string p)
        {
            letzteAbfrage = DateTime.Now;
            if (p == englischeÜbersetzung)
            {
                zahlKorrekterAbfragen++;
                return true;
            }
            else
            {
                zahlFehlgeschlagenerAbfragen++;
                return false;
            }
        }
    }
}
