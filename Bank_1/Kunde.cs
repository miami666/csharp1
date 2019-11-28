public class Kunde
{
    public string Addresse { get; private set; }
    public TypdesKunden kundentyp { get; set; }

    public Kunde(string addresse, TypdesKunden type)
    {
        this.Addresse = addresse;
        this.kundentyp = type;
    }
}

