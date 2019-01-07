using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Dzokej
    {
        public Dzokej()
        {
            ListaStartowa = new HashSet<ListaStartowa>();
        }

        public int NrDzokej { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? Wiek { get; set; }
        public double? Waga { get; set; }
        public string Biografia { get; set; }

        public ICollection<ListaStartowa> ListaStartowa { get; set; }
    }
}
