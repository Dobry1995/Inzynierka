using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ProfileDtos;
using Backend.Repositories.ProfilesRepositories;

namespace Backend.Services.ProfileServices
{
    public class GraczProfileService : IGraczProfileService
    {
        private readonly IGraczProfileRepository _drep;


        public GraczProfileService(IGraczProfileRepository drep)
        {
            _drep = drep;

        }
        public async Task<List<ProfileDTO.GraczProfil>> GetAll()
        {
            var result = _drep.GetAsyncProfiles();
            return await result;
        }

        public async Task<ProfileDTO.GraczProfil> GetAsyncProfile(int id)
        {
            var result = _drep.GetAsyncProfile(id);
            return await result;
        }
    }
}
