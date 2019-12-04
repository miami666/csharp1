public class Kunde
{
    public string Addresse { get; private set; }
    public TypdesKunden kundentyp { get; set; }
    public int Kartennummer { get; set; }
    public int PinCode { get; set; }




    //protected Kunde()
    //{

    //}

    protected Kunde(string addresse, TypdesKunden type, int _kartennummer, int _pincode)
    {
        this.Addresse = addresse;
       this.kundentyp = type;
        this.Kartennummer = _kartennummer;
        this.PinCode = _pincode;

    }
}

