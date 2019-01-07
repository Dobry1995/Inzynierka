using Backend.DTOs.ProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.ProfilesRepositories
{
    public interface IGraczProfileRepository
    {
        Task<ProfileDTO.GraczProfil> GetAsyncProfile(int id);
        Task<List<ProfileDTO.GraczProfil>> GetAsyncProfiles(); 
    }
}
