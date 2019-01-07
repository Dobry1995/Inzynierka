using Backend.DTOs.ProfileDtos;
using Backend.Models;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IDzokejService
    {
        Task<ProfileDTO.DzokejProfil> GetAsyncProfile(int id);
         Task <List<ProfileDTO.DzokejProfil>>GetAll();
    }
}
