using System;

public abstract class BankAccount : IDepositable
{
    //accounts have customer, balance and interest rate (monthly based)
    protected Customer customer;
    protected decimal balance;
    protected decimal interestRate;
    public decimal InterestAmount { get; protected set; }
    public int periodInMonths; 

    public Customer Customer
    {
        get { return this.customer; }
        set
        {
            this.customer = value;
        }
    }

    public decimal Kontostand
    {
        get { return this.balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.balance = value;
        }
    }

    public decimal InterestRate
    {
        get { return this.interestRate; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.interestRate = value;
        }
    }

    public int PeriodInMonths
    {
        get { return this.periodInMonths; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Balance can not be negative: {0}", value));
            }
            this.periodInMonths = value;
        }
    }

    public BankAccount(Customer customer, decimal balance, decimal interestRate, int periodInMonths)
    {
        this.Customer = customer;
        this.Kontostand = balance;
        this.InterestRate = interestRate;
        this.PeriodInMonths = periodInMonths;
    }

    public abstract decimal CalculateInterestAmount();
    public abstract decimal DepositeMoney(decimal money);
}

