public class Firma : Kunde
{
    public string FirmaName { get; set; }
    public TypderFirma _firmatyp { get; set; }

    public Firma(string _firmaname, string _adresse, TypderFirma _firmatyp, int _kartennummer, int _pincode)
        : base(_adresse, TypdesKunden.Firma, _kartennummer,_pincode)
    {
        this.FirmaName = _firmaname;
        this._firmatyp = _firmatyp;
    }
}

