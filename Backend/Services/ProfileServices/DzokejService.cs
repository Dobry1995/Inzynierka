using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOs.ProfileDtos;
using Backend.Models;
using Backend.Repositories;
using Backend.ViewModels;

namespace Backend.Services
{
    public class DzokejService : IDzokejService
    {
        private readonly IDzokejRepository _drep;
        

        public DzokejService(IDzokejRepository drep)
        {
            _drep = drep;
            
        }

        public async Task<List<ProfileDTO.DzokejProfil>> GetAll()
        {
            var result = _drep.GetAsyncProfiles();
            return await result;
        }

        public async Task<ProfileDTO.DzokejProfil> GetAsyncProfile(int id)
        {
            var result = _drep.GetAsyncProfil(id);
            return await result;
        }
    }
}
