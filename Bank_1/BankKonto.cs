using System;

public abstract class BankKonto : IEinzahlung
{
    //accounts have customer, balance and interest rate (monthly based)
    protected Kunde kunde;
    protected decimal kontostand;
    protected decimal zinsrate;
    public decimal Zinsen { get; protected set; }
    public int zeitrauminmonaten; 

    public Kunde Kunde
    {
        get { return this.kunde; }
        set
        {
            this.kunde = value;
        }
    }

    public decimal Kontostand
    {
        get { return this.kontostand; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.kontostand = value;
        }
    }

    public decimal Zinsrate
    {
        get { return this.zinsrate; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.zinsrate = value;
        }
    }

    public int ZeitraumMonate
    {
        get { return this.zeitrauminmonaten; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.zeitrauminmonaten = value;
        }
    }

    public BankKonto(Kunde customer, decimal balance, decimal interestRate, int periodInMonths)
    {
        this.Kunde = customer;
        this.Kontostand = balance;
        this.Zinsrate = interestRate;
        this.ZeitraumMonate = periodInMonths;
    }

    public abstract decimal BerechneZinsen();
    public abstract decimal GeldEinzahlen(decimal money);
}

