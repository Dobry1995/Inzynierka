using Backend.DTOs;
using Backend.DTOs.UpdateProfileDtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IGraczService
    {
        Gracz Authenticate(string login, string password);
        List<Gracz> PodajWszystkich();
        Gracz PodajJednegoPoId(int id);
        Gracz Stworz(Gracz gracz, string haslo);
        void Aktualizacja(Gracz graczParam,string haslo =null);
        void AktualizacjaHasla(Gracz graczparam, string haslo);
        void Usuwanie(int id);
        IActionResult AuthenticateInAction(string Login, string Haslo);
        IActionResult RegisterInAction(GraczDTO graczDTO);
        IActionResult UpdateInAction(int id, ProfileUpdatesDTO.GraczProfil graczDTO);
        IActionResult UpdatePasswordInAction(int id, ProfileUpdatesDTO.GraczHaslo graczDTO);
    }
}
