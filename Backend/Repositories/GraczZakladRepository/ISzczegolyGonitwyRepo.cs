using Backend.DTOs;
using Backend.DTOs.ZakladDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.GraczZakladRepository
{
    public interface ISzczegolyGonitwyRepo
    {
        Task<GonitwaListaDTO> GetAsyncListaWyscigu(int id);
        Task<GonitwaListaDTO.SzczegolyGonitwys> GetAsyncSzczegolyWyscigu(int id);
    }
}
