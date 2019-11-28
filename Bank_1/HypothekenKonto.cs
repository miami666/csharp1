using System;

public class Hypothekenkonto : BankKonto
{
    public override decimal GeldEinzahlen(decimal mammon) 
    {
        return this.Kontostand += mammon;
    }
    
    /*Mortgage accounts have ½ interest for the first 12 months for companies 
    * and no interest for the first 6 months for individuals. */
    public override decimal BerechneZinsen() 
    {
        if (this.Kunde.kundentyp == TypdesKunden.Firma)
        {
            if (this.ZeitraumMonate > 12)
            {
                int vorherigerZeitraumMonate = this.ZeitraumMonate - 12;
                this.Zinsen = (12 * (this.Zinsrate/2)) + (vorherigerZeitraumMonate*this.Zinsrate);
                return this.Zinsen;
            }
            else if (this.ZeitraumMonate < 12)
            {
                this.Zinsen = this.ZeitraumMonate * (this.Zinsrate / 2);
            }         
        }
        if (this.Kunde.kundentyp == TypdesKunden.Individual)
        {
            if (this.ZeitraumMonate < 6)
            {
                return 0;
            }
            else
            {
                this.Zinsen = this.ZeitraumMonate * this.Zinsrate;
                return this.Zinsen;
            }
        }
        this.Zinsen = this.ZeitraumMonate * this.Zinsrate;
        return this.Zinsen; 
    }

    public Hypothekenkonto(Kunde kunde, decimal kontostand, decimal zinsrate, int zeitrauminmonaten)
        : base(kunde, kontostand, zinsrate, zeitrauminmonaten)
    {        
    }
}

