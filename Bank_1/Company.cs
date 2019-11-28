public class Firma : Customer
{
    public string CompanyName { get; set; }
    public TypeOfFirm TypeOfFirms { get; set; }

    public Firma(string companyName, string address, TypeOfFirm typeFirm)
        : base(address, TypeOfCustomer.Company)
    {
        this.CompanyName = companyName;
        this.TypeOfFirms = typeFirm;
    }
}

