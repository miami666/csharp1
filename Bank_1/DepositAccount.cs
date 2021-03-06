﻿using System;

class Einzahlungskonto : BankKonto, IDrawable
{
    // Deposit accounts are allowed to deposit and with draw money
    public decimal DrawMoney(decimal money)
    {
       return this.Kontostand -= money;
    }

    public override decimal GeldEinzahlen(decimal money) 
    {
        return this.Kontostand += money;
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

