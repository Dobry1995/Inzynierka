using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Zaklad
    {
        public int IdZakladu { get; set; }
        public int? RodzajZakladu { get; set; }
        public int? IdGonitwy { get; set; }
        public int? IdGracza { get; set; }

        public Gonitwa IdGonitwyNavigation { get; set; }
        public Gracz IdGraczaNavigation { get; set; }
        public RodzajZakladu RodzajZakladuNavigation { get; set; }
    }
}
