using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.UpdateProfileDtos
{
    public class ProfileUpdatesDTO
    {
        public class GraczProfil
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
            public int? Wiek { get; set; }
            public string Haslo { get; set; }
            public string Wyksztalcenie { get; set; }
        }
        public class GraczHaslo
        {
            public string Haslo { get; set;}
        }
    }
}
