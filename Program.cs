﻿using System;
using System.Collections.Generic;

namespace OOPEvidencijaVozackihDozvolaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vozac> listaPostojecihVozaca = new List<Vozac>();

            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }

        private static int PonudiPonovnoIzbornik(List<Vozac> listaPostojecihVozaca)
        {
            Console.WriteLine("-------------------------------");
            int broj;
            List<string> izbornik = new List<string>() { "Dodavanje postojeceg vozaca", "Azuriranje postojeceg vozaca", "Ispis svih vozaca", "Ispis vozaca sa vazecom vozackom dozvolom",
            "Ispis vozaca sa isteklom vozackom dozvolom", "Prekid rada programa"};

            Console.WriteLine("Dobrodošli na izbornik evidencije vozačkih dozvola. Odaberite što želite (broj označava broj i stavku koju ste odabrali");

            //ispisi vrijednosti iz izbornika
            for (int i = 0; i < izbornik.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i, izbornik[i]);
            }
            Console.WriteLine("-------------------------------");

            // zapamti broj
            broj = Convert.ToInt32(Console.ReadLine());

            //ovisno o broju, odaberi što dalje
            switch (broj)
            {
                case 0:
                    DodajNovogVozaca(listaPostojecihVozaca);
                    break;
                case 1:
                    AzuriranjePostojecegVozaca(listaPostojecihVozaca);
                    break;
                case 2:
                    IspisSvihVozaca(listaPostojecihVozaca);
                    break;
                case 3:
                    IspisSvihVozacaSaVazecomVozackomDozvolom(listaPostojecihVozaca);
                    break;
                case 4:
                    IspisSvihVozacaSaIsteklomVozackomDozvolom(listaPostojecihVozaca);
                    break;
                case 5:
                    Console.WriteLine("Prekidam rad programa");
                    break;
                default:
                    Console.WriteLine("Niste unijeli odgovarajući broj");
                    break;
            }
            return broj;
        }

        private static void DodajNovogVozaca(List<Vozac> listaPostojecihVozaca)
        {
            int broj;

            Console.WriteLine("Upiši ime na vozackoj dozvoli");
            string ime = Console.ReadLine();

            Console.WriteLine("Upiši prezime na vozackoj dozvoli");
            string prezime = Console.ReadLine();

            Console.WriteLine("Upiši OIB osobe na vozackoj dozvoli");
            double OIB = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Odaberi istek datuma vozacke dozvole u formatu (Mjesec Dan, Godina)");
            DateTime datum = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Odaberite kategoriju vozačke dozvole(broj označava broj i stavku koju ste odabrali)");
            Vozac vozac = new Vozac(ime, prezime, OIB, DateTime.Now.Date, datum);

            for (int i = 0; i < vozac.PopisKategorija.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i, vozac.PopisKategorija[i]);
            }
            broj = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Odabrali ste kategoriju: {0}", vozac.PopisKategorija[broj]);
            listaPostojecihVozaca.Add(vozac);

            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }

        private static void AzuriranjePostojecegVozaca(List<Vozac> listaPostojecihVozaca)
        {
            if (listaPostojecihVozaca.Count != 0)
            {
                Vozac azurirajOvogVozaca;
                Console.WriteLine("Dobrodošli na izbornik ažuriranja postojećih vozača. Napišite ime i prezime vozača kojeg želite promijeniti");
                for (int i = 0; i < listaPostojecihVozaca.Count; i++)
                {
                    Console.WriteLine("{0} {1}", listaPostojecihVozaca[i].Ime, listaPostojecihVozaca[i].Prezime);
                }
                string imeIPrezime = Console.ReadLine();

                foreach (var c in listaPostojecihVozaca)
                {
                    if (c.Ime == imeIPrezime.Split(' ')[0] && c.Prezime == imeIPrezime.Split(' ')[1])
                    {
                        Console.WriteLine("Odabrali ste ažurirati vozača imena {0} i prezimena {1}", c.Ime, c.Prezime);
                        azurirajOvogVozaca = new Vozac(c.Ime, c.Prezime, c.OIB, c.DatumIzdavanjaVozacke, c.DatumIstekaVozacke);
                        listaPostojecihVozaca.Remove(c);
                        break;
                    }
                }

                Console.WriteLine("Upiši novo ime na vozackoj dozvoli");
                string ime = Console.ReadLine();

                Console.WriteLine("Upiši novo prezime na vozackoj dozvoli");
                string prezime = Console.ReadLine();

                Console.WriteLine("Upiši novi OIB osobe na vozackoj dozvoli");
                double OIB = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Odaberi istek datuma vozacke dozvole u formatu (Mjesec Dan, Godina)");
                DateTime datum = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Odaberite novu kategoriju (broj označava broj i stavku koju ste odabrali)");
                Vozac vozac = new Vozac(ime, prezime, OIB, DateTime.Now.Date, datum);

                for (int i = 0; i < vozac.PopisKategorija.Count; i++)
                {
                    Console.WriteLine("{0} - {1}", i, vozac.PopisKategorija[i]);
                }
                listaPostojecihVozaca.Add(vozac);
            }
            else
            {
                Console.WriteLine("Trenutno nema ni jednog korisnika s vozačkom dozvolom.");
            }
            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }

        private static void IspisSvihVozaca(List<Vozac> listaPostojecihVozaca)
        {
            if (listaPostojecihVozaca.Count != 0)
            {
                for (int i = 0; i < listaPostojecihVozaca.Count; i++)
                {
                    Console.WriteLine(listaPostojecihVozaca[i].Ime + " " + listaPostojecihVozaca[i].Prezime);
                }
            }
            else
            {
                Console.WriteLine("Trenutno nema nijednog korisnika s vozačkom dozvolom. Ponovno pokrećem izbornik.");
            }

            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }

        private static void IspisSvihVozacaSaVazecomVozackomDozvolom(List<Vozac> listaPostojecihVozaca)
        {
            if (listaPostojecihVozaca.Count != 0)
            {
                for (int i = 0; i < listaPostojecihVozaca.Count; i++)
                {
                    if (listaPostojecihVozaca[i].DatumIstekaVozacke > DateTime.Now.Date)
                    {
                        string formatView = String.Format("Ime i prezime: " + listaPostojecihVozaca[i].Ime + " "
                            + listaPostojecihVozaca[i].Prezime + "- vozačka traje do - " + listaPostojecihVozaca[i].DatumIstekaVozacke);
                        Console.WriteLine(formatView);
                    }
                }
            }
            else
            {
                Console.WriteLine("Trenutno nema nijednog korisnika s važećom vozačkom dozvolom. Ponovno pokrećem izbornik.");
            }

            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }

        private static void IspisSvihVozacaSaIsteklomVozackomDozvolom(List<Vozac> listaPostojecihVozaca)
        {
            if (listaPostojecihVozaca.Count != 0)
            {
                for (int i = 0; i < listaPostojecihVozaca.Count; i++)
                {
                    if (listaPostojecihVozaca[i].DatumIstekaVozacke < DateTime.Now.Date)
                    {
                        string formatView = String.Format("Ime i prezime: " + listaPostojecihVozaca[i].Ime + " "
                        + listaPostojecihVozaca[i].Prezime + "- vozačka je trajala do - " + listaPostojecihVozaca[i].DatumIstekaVozacke);
                        Console.WriteLine(formatView);
                    }
                    else
                    {
                        Console.WriteLine("Trenutno u evidenciji nema vozača sa isteklom vozačkom dozvolom.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Trenutno nema nijednog korisnika s isteklom vozačkom dozvolom. Ponovno pokrećem izbornik.");
            }

            PonudiPonovnoIzbornik(listaPostojecihVozaca);
        }
    }
}
