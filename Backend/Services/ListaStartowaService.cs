using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Repositories;

namespace Backend.Services
{
    public class ListaStartowaService : IListaStartowaService
    {
        private readonly IListaStartowaRepository _repo;
        public ListaStartowaService(IListaStartowaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ListaWyscigowDTO.ListaStartowas>> GetAsyncListaWysciguById(int id)
        {
            var result = _repo.GetAsyncListaWysciguById(id);
            return await result;
        }
        public async Task<GraczZakladResponse> GetAsync(int id)
        {
            var result = _repo.GetAsync(id);
            return await result;
        }
    }
}
