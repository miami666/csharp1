public class Firma : Kunde
{
    public string FirmaName { get; set; }
    public TypderFirma _firmatyp { get; set; }

    public Firma(string _firmaname, string _adresse, TypderFirma _firmatyp)
        : base(_adresse, TypdesKunden.Firma)
    {
        this.FirmaName = _firmaname;
        this._firmatyp = _firmatyp;
    }
}

