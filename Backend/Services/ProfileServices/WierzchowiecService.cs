using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ProfileDtos;
using Backend.Repositories;

namespace Backend.Services.ProfileServices
{
    public class WierzchowiecService : IWierzchowiecService
    {
        private readonly IWierzchowiecRepository _context;
        public WierzchowiecService(IWierzchowiecRepository context)
        {
            _context = context;
        }
        public async Task<List<ProfileDTO.Wierzchowiec>> GetAllAsync()
        {
            var result= _context.GetAll();
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetById(int id)
        {
            var result = _context.GetById(id);
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByMasc(string masc)
        {
            var result = _context.GetByMasc(masc);
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByNazwa(string nazwa)
        {
            var result = _context.GetOneByName(nazwa);
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByRasa(string rasa)
        {
            var result = _context.GetByRasa(rasa);
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByWiek(int wiek)
        {
            var result = _context.GetByWiek(wiek);
            return await result;
        }

        public async Task<ProfileDTO.Wierzchowiec> GetByWlasciciel(string wlasciciel)
        {
            var result = _context.GetByWlasciciel(wlasciciel);
            return await result;
        }
    }
}
