using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ZakladDtos;
using Backend.Repositories;
using Backend.Repositories.GraczZakladRepository;

namespace Backend.Services.ZakladServices
{
    public class SzczegolyGonitwyService : ISzczegolyGonitwyService
    {
        private readonly ISzczegolyGonitwyRepo _repo;
        public SzczegolyGonitwyService(ISzczegolyGonitwyRepo repo)
        {
            _repo = repo;
        }
        public async Task<GonitwaListaDTO> GetAsync(int id)
        {


            var result = _repo.GetAsyncListaWyscigu(id);
            return await result;

        }

        public async Task<GonitwaListaDTO.SzczegolyGonitwys> GetAsyncSzczegoly(int id)
        {
            var result = _repo.GetAsyncSzczegolyWyscigu(id);
            return await result;
        }
    }
}
