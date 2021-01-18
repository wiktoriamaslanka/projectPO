using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    [Serializable]
    public class Zamowienia : Magazyn //dziedziczenie po magazynie
    {
        LinkedList<Produkt> zamowienie = new LinkedList<Produkt>();
        List<Produkt> listaPom = new List<Produkt>();

        public LinkedList<Produkt> Zamowienie { get => zamowienie; set => zamowienie = value; }
        public List<Produkt> ListaPom1 { get => listaPom; set => listaPom = value; }
        public Zamowienia() //konstruktor nieparametryczny
        {
            Zamowienie = new LinkedList<Produkt>();
        }      

        public void DodajProdukt(Produkt produkt) //dodawanie produktu do zamówienia
        {            
            Zamowienie.AddLast(produkt);
        }       

        public override string ToString() //przesłaniamy metode ToString
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Realizuję zamówienie:");
            foreach (Produkt p in Zamowienie)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString(); 
        }
        
    }
}
