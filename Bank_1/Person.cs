public class Person : Kunde
{
    public string Vorname { get; private set; }
    public string Nachname { get; private set; }
   
    public Person(string _vorname, string _nachname, string _adresse, int _kartennummer,int _pincode)
        : base(_adresse, TypdesKunden.Individual,_kartennummer,_pincode)
    {
        this.Vorname = _vorname;
        this.Nachname = _nachname;
        this.Kartennummer = _kartennummer;
        this.PinCode = _pincode;

    }
}

