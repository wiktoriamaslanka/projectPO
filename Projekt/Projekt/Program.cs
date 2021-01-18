using System;

namespace Projekt
{
    public class Program
    {
        public enum Rozmiary { XS, S, M, L, XL }
        public enum Dzial { Damski, Meski, Dzieciecy }
        public enum Rodzaje { Zimowe, Letnie, Wiosenne, Jesienne, Casual, Wieczorowe, Basic, Unisex }
        static void Main(string[] args)
        {
            Produkt p1 = new Produkt("Koszulka", Rodzaje.Letnie, Dzial.Damski, Rozmiary.S, "Czerwony", 60);
            Produkt p2 = new Produkt("Spodnie", Rodzaje.Zimowe, Dzial.Meski, Rozmiary.XL, "Czarny", 178.87);
            Produkt p3 = new Produkt("Bluza", Rodzaje.Unisex, Dzial.Meski, Rozmiary.XL, "Żółty", 250);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            //Console.WriteLine();

            ProduktPromocyjny pp1 = new ProduktPromocyjny("Spodnie", Rodzaje.Zimowe, Dzial.Meski, Rozmiary.XL, "Czarny", 178.87, 25);
            //Console.WriteLine(pp1);
            //Console.WriteLine();

            Magazyn m1 = new Magazyn();
            m1.Umiesc(p1);
            m1.Umiesc(p1);
            m1.Umiesc(p1);
            m1.Umiesc(p2);
            m1.Umiesc(pp1);
            Console.WriteLine(m1);
            Console.WriteLine();

            Console.WriteLine("Sprawdzam ilość produktu o kodzie: " + p1.kod);
            Console.WriteLine("Ilosc: " + m1.IloscProduktu(p1.kod));
            Console.WriteLine();

            Console.WriteLine("Sprawdzam dostępność produktu o kodzie: " + p2.kod);
            m1.DostepnoscProduktu(p2.kod);
            Console.WriteLine();

            Console.WriteLine("Usuwam produkt: " + p1.kod);
            m1.Usun(p1, 2);
            Console.WriteLine(m1);
            Console.WriteLine();

            Zamowienia z1 = new Zamowienia();
            SprawdzCzyDostepny(z1, p2);
            SprawdzCzyDostepny(z1, p1);
            //SprawdzCzyDostepny(z1, p3); //przykład z wyjątkiem
            Console.WriteLine(z1);
            Console.WriteLine(m1);
            


            Zwrot w1 = new Zwrot();
            DodajDoZwrotu(w1, p2, true);
            Console.WriteLine(w1);
            

            Console.WriteLine("XML:");
            m1.ZapiszXML("Zapisany.xml");
            Magazyn m2 = Magazyn.OdczytajXML("Zapisany.xml");
            Console.WriteLine(m2.ToString());
           

            Console.WriteLine(" ============== kopiowanie ===============");
            Produkt p10 = (Produkt)p1.Clone();              
            Console.WriteLine(p10);
            Console.WriteLine();

            
            m1.Umiesc(p3);
            m1.Umiesc(pp1);
            m1.Umiesc(p3);
            Console.WriteLine(m1);
            Console.WriteLine("===============SORTOWANIE PO KODZIE==============");
            m1.SortujPoKodzie();
            Console.WriteLine(m1);
            



            void SprawdzCzyDostepny(Zamowienia z, Produkt p) //sprawdzamy czy produkt jest dostępny
            {
                if (m1.IloscProduktu(p.kod) != 0)
                {
                    z.DodajProdukt(p);
                    m1.Usun(p, 1);
                }
                else
                {
                    throw new ProduktNotFoundException(); //wyjątek
                }
            }
            void DodajDoZwrotu(Zwrot zwrot, Produkt produkt, bool czyZwrotny) //czyZwrotny - czy nie został uszkodzony
            {
                if (czyZwrotny)
                {
                    zwrot.DodajZwr(produkt);
                }
                else
                {
                    Console.WriteLine("Produkt nie spełnia warunków zwrotu!!!");
                }
            }

            Console.ReadKey();

        }
    }
}
