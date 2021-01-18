

namespace Projekt
{
    interface IMagazynuje //tworzymy interfejs, który później wkorzystujemy w klasie magazyn
    {
        void Umiesc(Produkt produkt);
        bool Usun(Produkt produkt, int ilosc);
        int IloscProduktu(string kod);
        bool DostepnoscProduktu(string kod);
    }
}
