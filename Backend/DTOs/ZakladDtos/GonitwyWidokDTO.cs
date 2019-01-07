using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.ZakladDtos
{
    public class GonitwyWidokDTO
    {
        public int NrGonitwyWSezonie { get; set; }
        public int? NrGonitwyWDniu { get; set; }
        public string NazwaNagrody { get; set; }
        public TimeSpan? GodzinaRozpoczecia { get; set; }
        public DateTime? Data { get; set; }
        public int? Dlugosc { get; set; }
    }
}
