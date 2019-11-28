class BankDetails : IBankDetails
{
    ReturnedVal rv = new ReturnedVal();
    List<BankAccount> _accounts;

    public BankDetails()
    {
        _accounts = new List<BankAccount>();
    }

    public List<BankAccount> Account
    {
        get { return _accounts; }
    }


    public void CreateAccount(string name)
    {
        BankAccount account = new BankAccount();
        CalculateIBAN calculateIban = new CalculateIBAN();

        try
        {
            if (!String.IsNullOrEmpty(name))
            {
                account.Name = name;
                account.IBAN = calculateIban.IBAN();
                _accounts.Add(account);
                Console.WriteLine("Account created - Name: {0}, IBAN: {1}", account.Name, account.IBAN);
            }
            else
            {
                Console.WriteLine("Account name is null or empty.");
            }
        }
        catch (NullReferenceException ne)
        {
            Console.WriteLine(ne.StackTrace);
        }
    }

    public float Deposit()
    {
        string iban = rv.EnterIban();
        BankAccount account = rv.GetAccountByName(iban, _accounts);

        while (account == null)
        {
            Console.WriteLine("Account doesn't exist");
            iban = rv.EnterIban();
            account = rv.GetAccountByName(iban, _accounts);
        }

        float sum = rv.AmountToDeposit();
        while (sum <= 0)
        {
            Console.WriteLine("Amount cannot be less or equal than 0.");
            sum = 0;
            sum = rv.AmountToDeposit();
        }

        account.Sum += sum;
        Console.WriteLine("Added {0} to account {1}", sum, iban);

        return account.Sum;
    }

    public float Withdraw()
    {
        BankDetails details = new BankDetails();
        BankAccount.Comision c = Comission.Comision;

        string iban = rv.EnterIban();
        BankAccount account = rv.GetAccountByName(iban, _accounts);

        while (account == null)
        {
            Console.WriteLine("Account doesn't exist");
            iban = rv.EnterIban();
            account = rv.GetAccountByName(iban, _accounts);
        }

        float sum = rv.AmountToDeposit();
        while (sum <= 0)
        {
            Console.WriteLine("Amount cannot be less or equal than 0.");
            sum = 0;
            sum = rv.AmountToDeposit();
        }

        account.Sum -= sum;

        Console.Write("Withdrawn {0} from account {1}.", sum, iban);
        Console.WriteLine("Comision {0}", Math.Round(c(account.Sum), 2));
        account.Sum -= c(account.Sum);
        Console.WriteLine("Remaining: {0}", Math.Round(account.Sum, 2));

        return account.Sum;
    }

    public float Balance()
    {
        string iban = rv.EnterIban();
        BankAccount account = rv.GetAccountByName(iban, _accounts);

        Console.WriteLine("IBAN: {0} has {1} left", iban, account.Sum);

        return account.Sum;
    }
}