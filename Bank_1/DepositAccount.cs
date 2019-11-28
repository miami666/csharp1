using System;

class Einzahlungskonto : BankAccount, IDrawable
{
    // Deposit accounts are allowed to deposit and with draw money
    public decimal DrawMoney(decimal money)
    {
       return this.Kontostand -= money;
    }

    public override decimal DepositeMoney(decimal money) 
    {
        return this.Kontostand += money;
    }

    //Deposit accounts have no interest if their balance is positive and less than 1000.
    public override decimal CalculateInterestAmount()
    {
        if (this.Kontostand < 1000)
        {
            return 0;  
        }
        //number_of_months * interest_rate.
        this.InterestAmount = this.PeriodInMonths * this.InterestRate;
        return this.InterestAmount;
    }

    public Einzahlungskonto(Customer customer, decimal balance, decimal interestRate, int periodInMonths)
        : base(customer, balance, interestRate, periodInMonths)
    {
    }
}

