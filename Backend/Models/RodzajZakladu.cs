using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class RodzajZakladu
    {
        public RodzajZakladu()
        {
            Zaklad = new HashSet<Zaklad>();
        }

        public int Id { get; set; }
        public string NazwaZakladu { get; set; }

        public ICollection<Zaklad> Zaklad { get; set; }
    }
}
