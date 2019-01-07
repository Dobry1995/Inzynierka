using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ProfileDtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.ProfilesRepositories
{
    public class GraczProfileRepository : IGraczProfileRepository
    {
        private readonly TotalizatorContext _context;
        public GraczProfileRepository(TotalizatorContext context)
        {
            _context = context;

        }
        public async Task<ProfileDTO.GraczProfil> GetAsyncProfile(int id)
        {
            return await _context.Gracz.Where(s => s.IdGracza == id).Select(l => new ProfileDTO.GraczProfil()
            {
                IdGracza=l.IdGracza,
                Imie = l.Imie,
                Nazwisko = l.Nazwisko,
                Login = l.Login,
                Rola=l.Rola,
                Email=l.Email,
                Wiek=l.Wiek,
                Wyksztalcenie=l.Wyksztalcenie

            }).SingleOrDefaultAsync();
        }

        public async Task<List<ProfileDTO.GraczProfil>> GetAsyncProfiles()
        {
            return await _context.Gracz.Select(l => new ProfileDTO.GraczProfil()
            {
                IdGracza=l.IdGracza,
                Imie = l.Imie,
                Nazwisko = l.Nazwisko,
                Login = l.Login,
                Rola=l.Rola,
                Email = l.Email,
                Wiek = l.Wiek,
                Wyksztalcenie = l.Wyksztalcenie

            }).ToListAsync();
        }
        //inserty 
        
    }
}
