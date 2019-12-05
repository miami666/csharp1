using System;
using System.Collections.Generic;
namespace FlugReservierung
{
    public class Boeing : IFlugzeug
    {
        public int Kapazität => 200;
        public float BenzinVerbrauch => 20;
        public List<string> Sitze => new List<string>(new string[] { "A", "B", "C", "D" });
        public Dictionary<int, List<string>> BelegteSitze = new Dictionary<int, List<string>>();
        
        public void ZeigeSitze()
        {
            ZeichneFlugzeugFront(8);
            ZeichneSitzReihen(50, this.BelegteSitze);
        }

        Dictionary<int, List<string>> IFlugzeug.BelegteSitze()
        {
            return this.BelegteSitze;
        }

        public void AddBelegterSitz(string sitz)
        {
            int sitzReihen = int.Parse(sitz.Substring(1, sitz.Length - 1));
            string sitzAbk = sitz.Substring(0, 1).ToUpper();
            this.BelegteSitze.Add(sitzReihen, new List<string>());
            this.BelegteSitze[sitzReihen].Add(sitzAbk);
        }


        private void ZeichneFlugzeugFront(int frontLength)
        {
            string spaces = "";
            int paddingNumber = frontLength * 2;
            string padding = AddPadding(paddingNumber);

            for (int i = 0; i < frontLength; i++)
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
        private void ZeichneSitzReihen(int rows, Dictionary<int, List<string>> belegteSitze)
        {
            string a;
            string b;
            string c;
            string d;
            for (int i = 1; i <= rows; i++)
            {
                a = "A";
                b = "B";
                c = "C";
                d = "D";
                if (belegteSitze.ContainsKey(i))
                {
                    foreach (var sitz in belegteSitze[i])
                    {
                        switch (sitz)
                        {
                            case "A":
                                a = "X";
                                break;
                            case "B":
                                b = "X";
                                break;
                            case "C":
                                c = "X";
                                break;
                            case "D":
                                d = "X";
                                break;
                        }
                    }
                }
                Console.WriteLine($"        | [{a}][{b}]  [{c}][{d}] | {i}");
            }
        }
    }
}