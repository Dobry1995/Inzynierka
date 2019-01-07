using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Gonitwa
    {
        public Gonitwa()
        {
            ListaStartowa = new HashSet<ListaStartowa>();
            Zaklad = new HashSet<Zaklad>();
        }

        public int NrGonitwyWSezonie { get; set; }
        public int? NrGonitwyWDniu { get; set; }
        public int? NrSzczegoly { get; set; }

        public Szczegoly NrSzczegolyNavigation { get; set; }
        public ICollection<ListaStartowa> ListaStartowa { get; set; }
        public ICollection<Zaklad> Zaklad { get; set; }
    }
}
