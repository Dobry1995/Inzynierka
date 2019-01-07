using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Gracz
    {
        public Gracz()
        {
            Zaklad = new HashSet<Zaklad>();
        }

        public int IdGracza { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public byte[] HashHaslo { get; set; }
        public byte[] SaltHaslo { get; set; }
        public string Rola { get; set; }
        public string Email { get; set; }
        public int? Wiek { get; set; }
        public string Wyksztalcenie { get; set; }

        public ICollection<Zaklad> Zaklad { get; set; }
    }
}
