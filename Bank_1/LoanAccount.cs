using System;

public class Darlehenskonto : BankAccount
{

    public Darlehenskonto(Customer customer, decimal balance, decimal interestRate, int periodInMonths)
        : base(customer, balance, interestRate, periodInMonths)
    {
    }

    public override decimal DepositeMoney(decimal money)
    {
       return this.Kontostand += money;
    }

    public override decimal CalculateInterestAmount()
    {
        if (this.PeriodInMonths >= 3 && customer.TypeOfCustomer == TypeOfCustomer.Individual)
        {
            this.InterestAmount = (this.PeriodInMonths - 3) * this.InterestRate;
            return this.InterestAmount;
        }
        else if (this.PeriodInMonths >= 2 && customer.TypeOfCustomer == TypeOfCustomer.Company)
        {
            this.InterestAmount = (this.PeriodInMonths - 2) * this.InterestRate;
            return this.InterestAmount;
        }
        else if ((this.PeriodInMonths < 3 && customer.TypeOfCustomer == TypeOfCustomer.Individual) || (this.PeriodInMonths < 2 && customer.TypeOfCustomer == TypeOfCustomer.Company))
        {
            return 0;
        }
        else
        {
            return this.PeriodInMonths * this.InterestRate;
        }
    }
}
