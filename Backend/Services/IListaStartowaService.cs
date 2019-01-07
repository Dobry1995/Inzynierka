using Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IListaStartowaService
    {
        Task<List<ListaWyscigowDTO.ListaStartowas>> GetAsyncListaWysciguById(int id);
        Task<GraczZakladResponse> GetAsync(int id);
    }
}
