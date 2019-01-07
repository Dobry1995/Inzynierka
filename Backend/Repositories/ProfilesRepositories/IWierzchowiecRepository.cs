using Backend.DTOs.ProfileDtos;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IWierzchowiecRepository
    {

         Task<List<ProfileDTO.Wierzchowiec>>GetAll();
        Task<ProfileDTO.Wierzchowiec> GetById(int id);
        Task<ProfileDTO.Wierzchowiec> GetByRasa(string rasa);
        Task<ProfileDTO.Wierzchowiec> GetByWiek(int wiek);
        Task<ProfileDTO.Wierzchowiec> GetByMasc(string masc);
        Task<ProfileDTO.Wierzchowiec> GetByPlec(string plec);
        Task<ProfileDTO.Wierzchowiec> GetByWlasciciel(string Wlasciciel);
       Task<ProfileDTO.Wierzchowiec> GetOneByName(string name);

    }
}
