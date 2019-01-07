using Backend.DTOs.ZakladDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.ZakladServices
{
    public interface ISzczegolyGonitwyService
    {
        Task<GonitwaListaDTO> GetAsync(int id);
        Task<GonitwaListaDTO.SzczegolyGonitwys> GetAsyncSzczegoly(int id);
    }
}
