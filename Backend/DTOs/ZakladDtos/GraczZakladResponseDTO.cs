using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.ZakladDtos
{
    public class GZakladResponseDTO
    {

        public int IdGracza { get; set; }
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
        public string Login { set; get; }
        public ICollection<Zaklads> Zaklad { get; set; }
    }
    public class Zaklads
    {
        public int NrGonitwyWSezonie { get; set; }
        public string NazwaNagrody { get; set; }
        public int? IdRodzajZakladu { get; set; }
        public int? IdGracza { get; set; }
        public string NazwaRodzaju { get; set; }

    }

}

