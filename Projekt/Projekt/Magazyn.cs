using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projekt
{
    [Serializable]  //atrybut, pozwala na zapis (w naszym przypadku klasy) do pliku na dysku
    public class Magazyn : IMagazynuje //wykorzystanie utworzonego interfejsu
    {
        public Queue<Produkt> listaProduktow;
        List<Produkt> listaPom;

        public Queue<Produkt> ListaProduktow { get => listaProduktow; set => listaProduktow = value; }
        public List<Produkt> ListaPom { get => listaPom; set => listaPom = value; }

        public Magazyn() //konstruktor nieparametryczny
        {
            listaProduktow = new Queue<Produkt>();
            ListaPom = new List<Produkt>();
        }
        public void Umiesc(Produkt produkt) //dodawanie produktu
        {
            listaProduktow.Enqueue(produkt);
        }
        public bool Usun(Produkt produkt, int ilosc) //usuwanie produktu
        {
            List<Produkt> nowa = new List<Produkt>(listaProduktow);
            List<Produkt> nowa1 = new List<Produkt>();
            bool f = false;
            int sprawdz = 0;
            foreach(Produkt p in nowa)
            {
                if (p.Equals(produkt))
                {
                    if (sprawdz == ilosc)
                    {
                        nowa1.Add(p);
                    }
                    else
                    {
                        sprawdz++;
                        f = true;
                    }
                    
                }
                else
                    nowa1.Add(p);               
            }           
            listaProduktow = new Queue<Produkt>(nowa1);
            return f;
        }
        public int IloscProduktu(string kod) //ilość produktu w magazynie
        {
            List<Produkt> nowalista = new List<Produkt>();
            foreach(Produkt p in listaProduktow)
            {
                if (p.kod.Equals(kod))
                {
                    nowalista.Add(p);
                }
            }
            return nowalista.Count();
        }
        public bool DostepnoscProduktu(string kod) //dostępność produktu sprawdzamy po kodzie
        {
            bool f = false;
            foreach(Produkt p in listaProduktow)
            {
                if (p.kod.Equals(kod))
                    f = true;                
            }  
            if(f==false)
                Console.WriteLine("Niedostępny");
            else
                Console.WriteLine("Dostępny");
            return f;
        }
        public void Sortuj() //sortowanie alfabetycznie po nazwie
        {
            List<Produkt> nowa = new List<Produkt>(listaProduktow);
            nowa.Sort();
            listaProduktow = new Queue<Produkt>(nowa);
        }
        public void SortujPoKodzie() //sortowanie produktów po kodzie alfabetycznie
        {
            List<Produkt> nowa = new List<Produkt>(listaProduktow);
            nowa.Sort(new KodComparator());
            listaProduktow = new Queue<Produkt>(nowa);
        }
        public void ZapiszXML(string nazwaPliku) //zapis pliku do XML
        {
            ListaPom = new List<Produkt>(ListaProduktow);
            XmlSerializer bf = new XmlSerializer(typeof(List<Produkt>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                bf.Serialize(sw, ListaPom);
            }
        }
        public static Magazyn OdczytajXML(string nazwaPliku) //odczyt pliku z XML
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            Magazyn o = new Magazyn();
            XmlSerializer bf = new XmlSerializer(typeof(List<Produkt>));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                o.ListaPom = (List<Produkt>)(bf.Deserialize(sw));
            }
            o.listaProduktow = new Queue<Produkt>(o.ListaPom);
            return o;
        }       
      

        public override string ToString() //przesłaniamy metode ToString
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stan magazynu:");
            foreach(Produkt p in listaProduktow)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
    //klasa potrzebna do sortowania po kodzie
    class KodComparator : IComparer<Produkt> //implementujemy interfejs IComparer, żeby porównać dwa produkty
    {
        public int Compare(Produkt x, Produkt y)
        {
            if (x != null && y != null)
            {
                return x.Kod.CompareTo(y.Kod);
            }
            return 0;
        }
    }
}
