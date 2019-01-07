using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs
{
    public class ListaWyscigowDTO
    {
        public class ListaStartowas
        {
            public int NrWierzchowca { get; set; }
            public string NazwaWierzchowca { get; set; }
            public int NrDzokeja { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }


        }

    }
}
