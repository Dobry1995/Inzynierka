using Backend.DTOs.ZakladDtos;
using Backend.Repositories;
using Backend.Repositories.ReposZaklad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.ZakladServices
{
    public class GraczZakladyService :  IGraczZakladyService
    {
        private readonly IGraczZakladyRepo _contextRepo;
        public GraczZakladyService(IGraczZakladyRepo contextRepo)
        {
            _contextRepo = contextRepo;
        }
        public async Task<GZakladResponseDTO> GetAsyncLista(int id)
        {
            var result = _contextRepo.GetAsync(id);
            return await result;
        }
    }
}
