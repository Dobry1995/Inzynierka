using Backend.DTOs;
using Backend.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Repositories
{
    public class ListaStartowaRepository : IListaStartowaRepository
    {
        private readonly TotalizatorContext _context;
        public ListaStartowaRepository(TotalizatorContext context)
        {
            _context = context;
        }
        public async Task<List<ListaWyscigowDTO.ListaStartowas>> GetAsyncListaWysciguById(int id)
        {
            return await _context.ListaStartowa
                .Where(s => s.NrGonitwyWSezonie == id)
            .Select(l => new ListaWyscigowDTO.ListaStartowas()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NrWierzchowcaNavigation.NazwaWierzchowca,
                NrDzokeja = l.NrDzokeja,
                Imie = l.NrDzokejaNavigation.Imie,
                Nazwisko = l.NrDzokejaNavigation.Nazwisko
            }).ToListAsync();
        }
        public async Task<GraczZakladResponse> GetAsync(int id)
        {
            return await _context.Gonitwa
                .Where(s => s.NrGonitwyWSezonie == id)
                .Select(l => new GraczZakladResponse()
                {
                    NrGonitwyWSezonie = l.NrGonitwyWSezonie,
                    NrGonitwyWDniu = l.NrGonitwyWDniu,
                    Zaklad = l.Zaklad.Where(p => p.IdGonitwy == l.NrGonitwyWSezonie).Select(c => new Zaklads
                    {
                        IdZakladu = c.IdZakladu,
                        IdGonitwy = c.IdGonitwy,
                        IdGracza = c.IdGracza,
                        Nazwisko = c.IdGraczaNavigation.Nazwisko,
                        NazwaZakladu = c.RodzajZakladuNavigation.NazwaZakladu

                    }).ToList(),
                    ListaStartowa = l.ListaStartowa.Where(d => d.NrGonitwyWSezonie == l.NrGonitwyWSezonie).Select(e => new ListaStartowas
                    {
                        IdListy = e.IdListy,
                        NrWierzchowca = e.NrWierzchowca,
                        NazwaWierzchowca = e.NrWierzchowcaNavigation.NazwaWierzchowca,
                        Rasa = e.NrWierzchowcaNavigation.Rasa,
                        Wiek = e.NrWierzchowcaNavigation.Wiek
                    }).ToList()



                }).SingleOrDefaultAsync();
        }
    }
}
