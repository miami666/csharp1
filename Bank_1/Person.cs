public class Person : Customer
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(string firstName, string lastName, string address)
        : base(address, TypeOfCustomer.Individual)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

