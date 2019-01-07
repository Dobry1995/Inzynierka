using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.DTOs.ProfileDtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{

    public class DzokejRepository : IDzokejRepository
    {
        private readonly TotalizatorContext _context;
        
        public DzokejRepository(TotalizatorContext context)
        {
            _context = context;
            
        }


        public async Task<ProfileDTO.DzokejProfil> GetAsyncProfil(int id)
        {
            return await _context.Dzokej.Where(s => s.NrDzokej == id).Select(l => new ProfileDTO.DzokejProfil()
            {
                Imie = l.Imie,
                Nazwisko = l.Nazwisko,
                Wiek = l.Wiek,
                Waga = l.Waga,
                Biografia = l.Biografia
            }).SingleOrDefaultAsync();
        }
        public async Task<List<ProfileDTO.DzokejProfil>> GetAsyncProfiles()
        {
            return await _context.Dzokej.Select(l => new ProfileDTO.DzokejProfil()
            {
                Imie = l.Imie,
                Nazwisko = l.Nazwisko,
                Wiek = l.Wiek,
                Waga = l.Waga,
                Biografia = l.Biografia
            }).ToListAsync();
        }


    }
}
