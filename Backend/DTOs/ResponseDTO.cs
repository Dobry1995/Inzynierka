
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Backend.DTOs.GraczZakladResponse;

namespace Backend.DTOs
{
    public class GraczZakladResponse
    {

        //gracz
        public int NrGonitwyWSezonie { get; set; }
        public int? NrGonitwyWDniu { get; set; }

        public ICollection<ListaStartowas> ListaStartowa { get; set; }
        public ICollection<Zaklads> Zaklad { get; set; }
    }
    //zaklad
    public partial class Zaklads
    {
        public int IdZakladu { get; set; }
        public int? IdGonitwy { get; set; }
        public int? IdGracza { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaZakladu { get; set; }

        public RodzajZakladus RodzajZakladuNavigation { get; set; }
        public GraczZakladResponse IdGonitwyNavigation { get; set; }
        public Graczs IdGraczaNavigation { get; set; }
    }

    public partial class RodzajZakladus
    {
        public string NazwaZakladu { get; set; }

        public ICollection<Zaklads> Zaklad { get; set; }
    }
    //gonitwa
    public partial class Graczs
    {
        public int IdGracza { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public ICollection<Zaklads> Zaklad { get; set; }


    }
    //lista startowa
    public class ListaStartowas
    {
        public int IdListy { get; set; }
        public int NrGonitwyWSezonie { get; set; }
        public int NrWierzchowca { get; set; }
        public int NrDzokeja { get; set; }


        public GraczZakladResponse NrGonitwyWSezonieNavigation { get; set; }
        public Wierzchowiecs NrWierzchowcaNavigation { get; set; }

        public string NazwaWierzchowca { get; set; }
        public string Rasa { get; set; }
        public int? Wiek { get; set; }
    }
    //Wierzchowiec
    public partial class Wierzchowiecs
    {
        public int NrWierzchowca { get; set; }
        public string NazwaWierzchowca { get; set; }
        public string Rasa { get; set; }
        public int? Wiek { get; set; }
        public string Umaszczenie { get; set; }

        public ICollection<ListaStartowas> ListaStartowa { get; set; }
    }
}



