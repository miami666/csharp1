public class Kunde
{
    public string Addresse { get; private set; }
    public TypdesKunden kundentyp { get; set; }



    //protected Kunde()
    //{

    //}

    protected Kunde(string addresse, TypdesKunden type)
    {
        this.Addresse = addresse;
       this.kundentyp = type;
       
    }
}

