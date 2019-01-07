using Backend.DTOs;
using Backend.DTOs.ProfileDtos;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IDzokejRepository
    {
        Task<ProfileDTO.DzokejProfil> GetAsyncProfil(int id);
        Task<List<ProfileDTO.DzokejProfil>> GetAsyncProfiles();
        

    }
}
