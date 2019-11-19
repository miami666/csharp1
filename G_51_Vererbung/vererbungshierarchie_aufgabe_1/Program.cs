using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die beiden folgenden Klassen ein:

    Klasse Stadt
        Attribute: einwohnerzahl, name, istGroßstadt[bool] (alle private)
        Properties: Einwohnerzahl(get und set), Name(get), IstGroßstadt[string](get: "Stimmt!", FALLS istGroßstadt=true, SONST "Nein!") 
        Konstruktor: 
            Übergabewerte: int e, string n
            Funktion:      setzt: 
                           - einwohnerzahl=e 
                           - name=n
                           - istGroßstadt=true FALLS e>=100000, SONST false

    Klasse Landeshauptstadt (SUBKLASSE von Stadt!)
        Attribute: adresse (des Landtages) 
        Properties: Adresse(get und set)
        Konstruktor: 
            Übergabewerte: string a UND die Attribute des Basis-Klassen-Konstruktors
            Funktion:      setzt adresse=a UND übergibt die entsprechenden Attribute an den Basis-Klassen-Konstruktor

    Testen Sie bitte die obigen Definitionen an folgendem Programm im Main:
    - Instanziierung der Städte Dinslaken(70000) und Wuppertal(350000)
    - Instanziierung der Landeshauptstadt Düsseldorf(620000 / Platz des Landtags 1, 40221 Düsseldorf)
    - Für alle drei Städte: Ausgabe von Name und Eigenschaft(Großstadt "Stimmt!" oder "Nein!")
    - Für die Landeshauptstadt: Ausgabe der Adresse (des Landtages)               
*/
class Stadt
{
    string name;
    int einwohnerzahl;
    bool istGrossstadt;
    public int Einwohnerzahl
    {
        get => einwohnerzahl;
        set {
        }
    }
    public string Name
    {
        get => name;
    }
    public string IstGrossstadt
    {
        get
        {
            string a = "Stimmt";
            string b = "Nein";
            if (istGrossstadt) return a;
            else return b;
        }
       
   
    }
    public Stadt()
    {

    }
    public Stadt(int e,string n)
    {
        einwohnerzahl = e;
        name = n;
        if (e >= 100000) istGrossstadt = true;
        else istGrossstadt = false;
        
    }
}
class Landeshauptstadt:Stadt
{
    string adresseLandtag;
    
    public string AdresseLandtag
    {
        get => adresseLandtag;
        set { }
    }
   
    public Landeshauptstadt(string a,int e,string n):base(e,n)
    {
        
        adresseLandtag = a;

    }

}
namespace vererbungshierarchie_aufgabe_1
{
    class Program
    { 
        static void Main(string[] args)
        {
            Stadt dinslaken = new Stadt(70000,"Dinslaken");
            Stadt wuppertal = new Stadt(350000, "Wuppertal");
            Landeshauptstadt duesseldorf = new Landeshauptstadt("Platz am Arsch 1", 620000, "Duesseldorf");
            Console.WriteLine("Kontrollausgabe");
            Console.WriteLine("Name: "+dinslaken.Name+" Einwohner: "+dinslaken.Einwohnerzahl+" Grossstadt: "+dinslaken.IstGrossstadt);
            Console.WriteLine("Name: " + wuppertal.Name + " Einwohner: " + wuppertal.Einwohnerzahl+" Grossstadt: "+wuppertal.IstGrossstadt);
            Console.WriteLine("Name: " + duesseldorf.Name + " Einwohner: " + duesseldorf.Einwohnerzahl+" Grossstadt: "+duesseldorf.IstGrossstadt);
            Console.ReadKey();


        }
    }
}
