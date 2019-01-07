using Backend.DTOs.ZakladDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.ZakladServices
{
    public interface IGraczZakladyService
    {
        // Lista zakladow gracza
        Task<GZakladResponseDTO> GetAsyncLista(int id);
    }
}
