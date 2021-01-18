using System;
using static Projekt.Program;

namespace Projekt
{
    [Serializable]
    public class ProduktPromocyjny : Produkt //dziedziczenie po klasie produkt
    {
        double wysokosc;    //wysokosc promocji
        public double cenaPromocyjna;

        public double CenaPromocyjna { get => cenaPromocyjna;  }
        public double Wysokosc { get => wysokosc; set => wysokosc = value; }

        public ProduktPromocyjny() : base() //konstruktor nieparametryczny
        {
            wysokosc = 0;
            cenaPromocyjna = 0;
        }
        public ProduktPromocyjny(string _nazwa, Rodzaje _rodzaj, Dzial _dzial, Rozmiary _rozmiar, string _kolor, double _cena, double _wysokosc) : base(_nazwa,_rodzaj,_dzial, _rozmiar, _kolor, _cena) //konstruktor parametryczny
        {
            wysokosc = _wysokosc;
            cenaPromocyjna = Math.Round(Cena * (100-wysokosc) / 100, 2);
            kod = $"P"+base.kod;
        }
        public override string ToString() //przesłaniamy metodę ToString
        {
            return $"PP {NazwaProduktu}, rodzaj: {Rodzaj}, kolor: {Kolor}, dział: {Dzial}, rozmiar: {Rozmiar}, wysokość promocji: {Wysokosc}%, cena po promocji: {CenaPromocyjna} zł,  kod: {kod}";
        } 

    }
}
