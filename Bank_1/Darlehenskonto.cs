using System;

public class Darlehenskonto : BankKonto
{

    public Darlehenskonto(Kunde kunde, decimal kontostand, decimal zinsrate, int zeitrauminmonaten)
        : base(kunde, kontostand, zinsrate, zeitrauminmonaten)
    {
    }

    public override decimal GeldEinzahlen(decimal mammon)
    {
       return this.Kontostand += mammon;
    }

    public override decimal BerechneZinsen()
    {
        if (this.ZeitraumMonate >= 3 && kunde.kundentyp == TypdesKunden.Individual)
        {
            this.Zinsen = (this.ZeitraumMonate - 3) * this.Zinsrate;
            return this.Zinsen;
        }
        else if (this.ZeitraumMonate >= 2 && kunde.kundentyp == TypdesKunden.Firma)
        {
            this.Zinsen = (this.ZeitraumMonate - 2) * this.Zinsrate;
            return this.Zinsen;
        }
        else if ((this.ZeitraumMonate < 3 && kunde.kundentyp == TypdesKunden.Individual) || (this.ZeitraumMonate < 2 && kunde.kundentyp == TypdesKunden.Firma))
        {
            return 0;
        }
        else
        {
            return this.ZeitraumMonate * this.Zinsrate;
        }
    }
}
