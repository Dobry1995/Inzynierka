using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ListaStartowa
    {
        public int IdListy { get; set; }
        public int NrGonitwyWSezonie { get; set; }
        public int NrWierzchowca { get; set; }
        public int NrDzokeja { get; set; }

        public Dzokej NrDzokejaNavigation { get; set; }
        public Gonitwa NrGonitwyWSezonieNavigation { get; set; }
        public Wierzchowiec NrWierzchowcaNavigation { get; set; }
    }
}
