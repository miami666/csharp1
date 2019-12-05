using System;
using System.Collections.Generic;
using System.Text;

namespace FlugReservierung
{
    public interface IFlugzeug
    {
        int Kapazität { get; }
        float BenzinVerbrauch { get; }
        List<string> Sitze { get; }
        void ZeigeSitze();
        Dictionary<int, List<string>> BelegteSitze();
        void AddBelegterSitz(string sitz);
    }
}
