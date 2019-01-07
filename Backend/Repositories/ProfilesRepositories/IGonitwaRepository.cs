using Backend.DTOs.ZakladDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IGonitwaRepository
    {
        Task<List<GonitwyWidokDTO>> GetAsyncWszystkieGonitwy();
        Task<List<GonitwyWidokDTO>> GetAsyncWszystkieGonitwyFuture();
        IActionResult PokazSzczegolyDanejGonitwy(int nrGonitwy);
        IActionResult PokazListeStartowaDanejGonitwy(int nrGonitwy);
    }
}
