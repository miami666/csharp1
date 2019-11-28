public class Person : Kunde
{
    public string Vorname { get; private set; }
    public string Nachname { get; private set; }

    public Person(string _vorname, string _nachname, string _adresse)
        : base(_adresse, TypdesKunden.Individual)
    {
        this.Vorname = _vorname;
        this.Nachname = _nachname;
    }
}

