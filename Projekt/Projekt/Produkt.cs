using System;
using System.Xml.Serialization;
using static Projekt.Program;

namespace Projekt
{
    [Serializable]
    [XmlInclude(typeof(ProduktPromocyjny))]
    public class Produkt : ICloneable, IComparable<Produkt> //Wykorzystanie interfejsów IClonable, IComparable – kopiowanie, sortowanie danych.
    {
        string nazwaProduktu;
        Rodzaje rodzaj;
        Dzial dzial;
        Rozmiary rozmiar;
        string kolor;
        public string kod;
        double cena;

        public string NazwaProduktu { get => nazwaProduktu; set => nazwaProduktu = value; }
        public Rodzaje Rodzaj { get => rodzaj; set => rodzaj = value; }
        public Rozmiary Rozmiar { get => rozmiar; set => rozmiar = value; }
        public string Kolor { get => kolor; set => kolor = value; }
        public Dzial Dzial { get => dzial; set => dzial = value; }
        public string Kod { get => kod; }
        public double Cena { get => cena; set => cena = value; }

        public Produkt() //kontruktor nieparametryczny
        {
            nazwaProduktu = null;
            kolor = null;
            kod = null;
            cena = 0;
        }
        public Produkt(string _nazwa, Rodzaje _rodzaj, Dzial _dzial, Rozmiary _rozmiar, string _kolor, double _cena) : this() //kontruktor parametryczny
        {          
            NazwaProduktu = _nazwa;
            Rodzaj = _rodzaj;
            Dzial = _dzial;
            Rozmiar = _rozmiar;
            Kolor = _kolor;
            Cena = _cena;
            kod = $"{nazwaProduktu.ToString().Substring(0,2).ToUpper()}-{rodzaj.ToString().Substring(0,2).ToUpper()}-{dzial.ToString().Substring(0,2).ToUpper()}-{rozmiar}{kolor.ToString().Substring(0,2).ToUpper()}";
        }

        public override string ToString() //przesłaniamy metodę ToString
        {
            return $"{NazwaProduktu}, rodzaj: {Rodzaj}, kolor: {Kolor}, dział: {Dzial}, rozmiar: {Rozmiar}, cena: {Cena} zł,  kod: {kod}";
        }

        public object Clone() //IClonable - kopiowanie
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Produkt other) //IComparable – sortowanie danych
        {
            if (other != null)
            {
                int cmp = this.Kod.CompareTo(other.Kod);
                return cmp;
            }
            else
                return 1;
        }
     
    }
}
