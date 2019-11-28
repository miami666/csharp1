using System;

class Einzahlungskonto : BankKonto, IAbhebung
{
    // Deposit accounts are allowed to deposit and with draw money
    public decimal Geldabheben(decimal mammon)
    {
       return this.Kontostand -= mammon;
    }

    public override decimal GeldEinzahlen(decimal mammon) 
    {
        return this.Kontostand += mammon;
    }

    //Deposit accounts have no interest if their balance is positive and less than 1000.
    public override decimal BerechneZinsen()
    {
        if (this.Kontostand < 1000)
        {
            return 0;  
        }
        //number_of_months * interest_rate.
        this.Zinsen = this.ZeitraumMonate * this.Zinsrate;
        return this.Zinsen;
    }

    public Einzahlungskonto(Kunde kunde, decimal kontostand, decimal zinsrate, int zeitrauminmonaten)
        : base(kunde, kontostand, zinsrate, zeitrauminmonaten)
    {
    }
}

