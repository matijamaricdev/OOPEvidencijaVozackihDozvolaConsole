using System;
using System.Collections.Generic;
using System.Text;

namespace OOPEvidencijaVozackihDozvolaConsole
{
//    Naslov zadataka: Evidencija vozačkih dozvola
//Opis zadatka: 
//Kreirajte klasu imena "Vozač" koja sadrži šest svojstava(varijabli):
//Ime
//Prezime
//OIB
//Datum izdavanja vozačke dozvole
//Datum isteka vozačke dozvole
//Popis kategorija vozila za koje vrijedi vozačka dozvola(složena struktura podataka)
//Kreirajte konstruktor koji prima pet parametara(svim parametri osim popisa kategorije vozila za koje vrijedi vozačka dozvola).
//Kreirajte get i set metode za sve parametre.Set metoda za popis kategorija vozila mora omogućiti dodavanje nove kategorije vozila u složenu strukturu podataka (u složenoj strukturi podataka ne smije biti duplikati) i brisanje jedne od kategorija vozila(preporuka: napraviti dvije set metode).
//Kreirajte C# program koji sadrži izbornik sa sljedećim opcijama:
//Dodavanje novog vozača
//Ažuriranje postojećeg vozača
//Ispis svih vozača
//Ispis vozača sa važećom vozačkom dozvolom
//Ispis vozača sa isteklom vozačkom dozvolom
//Prekid rada programa
//Podaci svih vozača moraju biti pohranjeni u listi, tj. svaki novi vozač(objekt) mora biti dodan u listu vozača.
//Opcija ažuriranja podataka postojećeg vozača mora omogućiti izmjenu podataka vozača iz liste.
//Nakon odabira određene opcije i izvođenja potrebnih operacija vezanih za odabranu opciju, program mora ponovo ponuditi izbornik i omogućiti korisniku novi izbor.
//Program se mora izvoditi sve dok na izborniku nije odabrana opcija prekida rada programa.
    public class Vozac
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public double OIB { get; set; }
        public DateTime DatumIzdavanjaVozacke { get; set; }
        public DateTime DatumIstekaVozacke { get; set; }
        public List<string> PopisKategorija { get; set; } = new List<string>() { "A", "B", "C", "D", "E", "F" }; 
        //shorthand set metoda, lako se doda nova kategorija sa PopisKategorija.Add("G") ili PopisKategorija.Remove("G")

        public Vozac(string ime, string prezime, double oib, DateTime datumIzdavanjaVozacke, DateTime datumIstekaVozacke)
        {
            Ime = ime;
            Prezime = prezime;
            OIB = oib;
            DatumIzdavanjaVozacke = datumIzdavanjaVozacke;
            DatumIstekaVozacke = datumIstekaVozacke;
        }
    }
}
