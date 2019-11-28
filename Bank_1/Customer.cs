public class Customer
{
    public string Address { get; private set; }
    public TypeOfCustomer TypeOfCustomer { get; set; }

    public Customer(string address, TypeOfCustomer type)
    {
        this.Address = address;
        this.TypeOfCustomer = type;
    }
}

