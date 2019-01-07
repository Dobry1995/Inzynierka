using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.ZakladDtos
{
    public class SzczegolyGonitwyDTO
    {
               
            public string NazwaNagrody { get; set; }
            public string WarunkiGonitwy { get; set; }
            public TimeSpan? GodzinaRozpoczęcia { get; set; }
            public DateTime? Data { get; set; }
            public int? Dlugosc { get; set; }
            public int? NagrodaZaIMiejsce { get; set; }
            public int? NagrodaZaIiMiejsce { get; set; }
            public int? NagrodaZaIiiMiejsce { get; set; }
            public int? NagrodaZaIvMiejsce { get; set; }
            public int? NagrodaZaVMiejsce { get; set; }
        }
    }

