using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    [Serializable]
    public class Zwrot
    {
        LinkedList<Produkt> listaZwrotow;
        bool czyZwrotny;
       
        public bool CzyZwrotny { get => czyZwrotny; set => czyZwrotny = value; }
        public LinkedList<Produkt> ListaZwrotow { get => listaZwrotow; set => listaZwrotow = value; }

        public Zwrot() //konstruktor nieparametryczny
        {
            ListaZwrotow = new LinkedList<Produkt>();
        }
        public void DodajZwr(Produkt produkt) //Dodawanie produktu do zwrotu
        {
            listaZwrotow.AddLast(produkt);            
        }
        public override string ToString() //przesłaniamy metodę ToString
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Realizuję zwrot:");
            foreach (Produkt p in listaZwrotow)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }

    }
}
