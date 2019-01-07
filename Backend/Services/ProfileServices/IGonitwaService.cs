using Backend.DTOs.ZakladDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.ProfileServices
{
    public interface IGonitwaService
    {
        Task<List<GonitwyWidokDTO>> GetAll();
        Task<List<GonitwyWidokDTO>> GetAllFuture();
    }
}
