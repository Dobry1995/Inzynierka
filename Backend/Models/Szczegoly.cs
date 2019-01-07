using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Szczegoly
    {
        public Szczegoly()
        {
            Gonitwa = new HashSet<Gonitwa>();
        }

        public int IdSzczegoly { get; set; }
        public string NazwaNagrody { get; set; }
        public string WarunkiGonitwy { get; set; }
        public TimeSpan? GodzinaRozpoczecia { get; set; }
        public DateTime? Data { get; set; }
        public int? Dlugosc { get; set; }
        public int? NagrodaZaIMiejsce { get; set; }
        public int? NagrodaZaIiMiejsce { get; set; }
        public int? NagrodaZaIiiMiejsce { get; set; }
        public int? NagrodaZaIvMiejsce { get; set; }
        public int? NagrodaZaVMiejsce { get; set; }

        public ICollection<Gonitwa> Gonitwa { get; set; }
    }
}
