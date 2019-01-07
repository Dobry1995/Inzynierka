using Backend.DTOs.ZakladDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.ReposZaklad
{
    public interface IGraczZakladyRepo
    {
        //Lista zakladów gracza
        Task<GZakladResponseDTO> GetAsync(int id);


    }
}
