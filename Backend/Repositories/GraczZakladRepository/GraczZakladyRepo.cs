using Backend.DTOs.ZakladDtos;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.ReposZaklad
{
    public class GraczZakladyRepo : IGraczZakladyRepo
    {
        private readonly TotalizatorContext _context;
        public GraczZakladyRepo(TotalizatorContext context)
        {
            _context = context;
        }
        public async Task<GZakladResponseDTO> GetAsync(int id)
        {
            return await _context.Gracz
                .Where(s => s.IdGracza == id)
                .Select(l => new GZakladResponseDTO()
                {
                    IdGracza = l.IdGracza,
                    Imie = l.Imie,
                    Nazwisko = l.Nazwisko,
                    Login = l.Login,
                    Zaklad = l.Zaklad.Where(p => p.IdGracza == l.IdGracza).Select(c => new Zaklads
                    {
                        NazwaNagrody=c.IdGonitwyNavigation.NrSzczegolyNavigation.NazwaNagrody,
                        NrGonitwyWSezonie=c.IdGonitwyNavigation.NrGonitwyWSezonie,
                        IdGracza = c.IdGracza,
                        IdRodzajZakladu = c.RodzajZakladuNavigation.Id,
                        NazwaRodzaju = c.RodzajZakladuNavigation.NazwaZakladu

                    }).ToList()


                }).SingleOrDefaultAsync();

        }
    }
}
