using Backend.DTOs.ProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.ProfileServices
{
    public interface IWierzchowiecService
    {
        Task<List<ProfileDTO.Wierzchowiec>> GetAllAsync();
        Task<ProfileDTO.Wierzchowiec> GetByMasc(string masc);
        Task<ProfileDTO.Wierzchowiec> GetByRasa(string rasa);
        Task<ProfileDTO.Wierzchowiec> GetByNazwa(string nazwa);
        Task<ProfileDTO.Wierzchowiec> GetById(int id);
        Task<ProfileDTO.Wierzchowiec> GetByWiek(int wiek);
        Task<ProfileDTO.Wierzchowiec> GetByWlasciciel(string wlasciciel);
    }
}
