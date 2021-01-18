using System;

namespace Projekt
{
    public class ProduktNotFoundException : Exception //dziedziczenie po klasie Exception
    {
        public ProduktNotFoundException()
        {
            Console.WriteLine("Brak produktu w magazynie");
        }
    }
}
