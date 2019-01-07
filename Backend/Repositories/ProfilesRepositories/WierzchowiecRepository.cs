using Backend.DTOs.ProfileDtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class WierzchowiecRepository : IWierzchowiecRepository
    {
        private readonly TotalizatorContext _context;
        public WierzchowiecRepository(TotalizatorContext context)
        {
            _context = context;
        }
        public async Task<ProfileDTO.Wierzchowiec> GetById(int id)
        {
            return await _context.Wierzchowiec.Where(s => s.NrWierzchowca == id).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }
        public async Task<List<ProfileDTO.Wierzchowiec>> GetAll()
        {
            return await _context.Wierzchowiec.Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).ToListAsync();
            
        }
        public async Task<ProfileDTO.Wierzchowiec> GetByMasc(int id)
        {
            return await _context.Wierzchowiec.Where(s => s.NrWierzchowca == id).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }
        public async Task<ProfileDTO.Wierzchowiec> GetByMasc(string masc)
        {
            return await _context.Wierzchowiec.Where(s=>s.Umaszczenie==masc).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByPlec(string plec)
        {
            return await _context.Wierzchowiec.Where(s => s.Plec == plec).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByRasa(string rasa)
        {
            return await _context.Wierzchowiec.Where(s => s.Rasa == rasa).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByWiek(int wiek)
        {
            return await _context.Wierzchowiec.Where(s => s.Wiek == wiek).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByWlasciciel(string Wlasciciel)
        {
            return await _context.Wierzchowiec.Where(s => s.Wlasciciel == Wlasciciel).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }

        public async Task<ProfileDTO.Wierzchowiec> GetOneByName(string name)
        {
            return await _context.Wierzchowiec.Where(s => s.NazwaWierzchowca == name).Select(l => new ProfileDTO.Wierzchowiec()
            {
                NrWierzchowca = l.NrWierzchowca,
                NazwaWierzchowca = l.NazwaWierzchowca,
                Plec = l.Plec,
                Wiek = l.Wiek,
                Wlasciciel = l.Wlasciciel,
                Rasa = l.Rasa,
                Umaszczenie = l.Umaszczenie,
                ZnakiSzczegolne = l.ZnakiSzczegolne
            }).SingleOrDefaultAsync();
        }
    }
}
