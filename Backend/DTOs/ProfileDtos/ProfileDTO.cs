using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.ProfileDtos
{
    public class ProfileDTO
    {
        public class DzokejProfil
        {

            public int NrDzokej { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public int? Wiek { get; set; }
            public double? Waga { get; set; }
            public string Biografia { get; set; }
        }
        public class GraczProfil
        {
            public int IdGracza { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Login { get; set; }
            public string Rola { get; set; }
            public string Email { get; set; }
            public int? Wiek { get; set; }
            public string Wyksztalcenie { get; set; }

        }
        public class Wierzchowiec
        {
            public int NrWierzchowca { get; set; }
            public string NazwaWierzchowca { get; set; }
            public string Rasa { get; set; }
            public int? Wiek { get; set; }
            public string Umaszczenie { get; set; }
            public string Plec { get; set; }
            public string ZnakiSzczegolne { get; set; }
            public string Wlasciciel { get; set; }
            
        }
    }
}
