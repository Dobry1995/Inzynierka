using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Wierzchowiec
    {
        public Wierzchowiec()
        {
            ListaStartowa = new HashSet<ListaStartowa>();
        }

        public int NrWierzchowca { get; set; }
        public string NazwaWierzchowca { get; set; }
        public string Rasa { get; set; }
        public int? Wiek { get; set; }
        public string Umaszczenie { get; set; }
        public string Plec { get; set; }
        public string ZnakiSzczegolne { get; set; }
        public string Wlasciciel { get; set; }

        public ICollection<ListaStartowa> ListaStartowa { get; set; }
    }
}
