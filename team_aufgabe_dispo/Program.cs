using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_namespace;
/*
 * Schreiben Sie ein C# Programm welches folgende Aufgaben erfüllt:
Konto verwaltet werden (für Privatkunden und Geschäftskunden) 
Erstellung im ctor
es soll geben
in eigener (extra) Datei einen eigenen namespace für
{
- eine abstrakte Klasse "Kunde"
	* mit abstrakter Methode Login (Ausgabe reicht)
		(Optional: mit PIN)
	* mit protected ctor
- eine public Klasse PrivatKunde, die von Kunde erbt
- eine public Klasse Geschäftskunde, die von Kunde erbt
}

in eigener (extra) Datei einen namespace KontoApp (wie program.cs) für
{
eine public Klasse Konto mit Kontonummer, BLZ, Kontoinhaber, Kontostand
jeweils mit Properties {get; private set;) und ctor
- Methoden Einzahlen und Abheben (keine negativen Werte)
}

Dies soll in main durch geeignete Wege getestet werden.
Optional: mit (Text-)Menü
Optional2: mit Dispo
 */
namespace team_aufgabe_dispo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
