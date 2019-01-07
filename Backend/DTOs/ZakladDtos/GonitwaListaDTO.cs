using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.ZakladDtos
{
    public class GonitwaListaDTO
    {

        public int NrGonitwyWSezonie { get; set; }
        public int? NrGonitwyWDniu { get; set; }
        //do listy
        public ICollection<ListaStartowas> ListaStartowa { get; set; }
        public class ListaStartowas
        {

            public int NrWierzchowca { get; set; }
            public string NazwaWierzchowca { get; set; }
            public int NrDzokeja { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }


        }
        public class SzczegolyGonitwys
        {
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
        }

    }
}

