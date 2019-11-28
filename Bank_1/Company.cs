public class Firma : Customer
{
    public string FirmaName { get; set; }
    public TypeOfFirm TypeOfFirms { get; set; }

    public Firma(string _firmaname, string _adress, TypeOfFirm _firmatyp)
        : base(_adress, TypeOfCustomer.Company)
    {
        this.FirmaName = _firmaname;
        this.TypeOfFirms = _firmatyp;
    }
}

