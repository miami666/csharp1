using System;
using System.Collections.Generic;

namespace FlugReservierung
{
    public class Airbus: IFlugzeug
    {

        public Airbus()
        {
        }
        public int Kapazität => 255;
        public float BenzinVerbrauch => 32;
        public List<string> Sitze => new List<string>(new string[] { "A", "B"});
        public Dictionary<int, List<string>> BelegteSitze = new Dictionary<int, List<string>>();

        public void ZeigeSitze()
        {
            ZeichneFlugzeugFront(6);
            ZeichneSitzReihen(50, this.BelegteSitze);
        }

        Dictionary<int, List<string>> IFlugzeug.BelegteSitze()
        {
            return this.BelegteSitze;
        }

        public void AddBelegterSitz(string sitz)
        {
            int sitzReihe = int.Parse(sitz.Substring(1, sitz.Length - 1));
            string sitzAbk = sitz.Substring(0, 1).ToUpper();
            if (!this.BelegteSitze.ContainsKey(sitzReihe))
            {
                this.BelegteSitze.Add(sitzReihe, new List<string>());
            }
            this.BelegteSitze[sitzReihe].Add(sitzAbk);
        }


        private void ZeichneFlugzeugFront(int frontLaenge)
        {
            string spaces = "";
            int paddingNumber = frontLaenge * 2;
            string padding = AddPadding(paddingNumber);

            for (int i = 0; i < frontLaenge; i++)
            {
                Console.WriteLine(padding + "/" + spaces + @"\");
                spaces += "  ";
                paddingNumber -= 1;
                padding = AddPadding(paddingNumber);
            }
        }
        private string AddPadding(int numberOfSpaces)
        {
            string temp = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                temp += " ";
            }
            return temp;
        }
        private void ZeichneSitzReihen(int reihen, Dictionary<int, List<string>> belegteSitze)
        {
            string a;
            string b;
            for (int i = 1; i <= reihen; i++)
            {
                a = "A";
                b = "B";
                if (belegteSitze.ContainsKey(i))
                {
                    foreach (var Sitz in belegteSitze[i])
                    {
                        switch (Sitz)
                        {
                            case "A":
                                a = "X";
                                break;
                            case "B":
                                b = "X";
                                break;
                        }
                    }
                }
                Console.WriteLine($"      | [{a}]    [{b}] | {i}");
            }
        }
    }
}