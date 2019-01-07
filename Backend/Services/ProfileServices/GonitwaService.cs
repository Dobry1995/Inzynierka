using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ZakladDtos;
using Backend.Repositories;

namespace Backend.Services.ProfileServices
{
    public class GonitwaService : IGonitwaService
    {
        private readonly IGonitwaRepository _context;
        public GonitwaService(IGonitwaRepository context)
        {
            _context = context;
        }

        public async  Task<List<GonitwyWidokDTO>> GetAll()
        {
            var result = _context.GetAsyncWszystkieGonitwy();
            return await result;
        }

        public async Task<List<GonitwyWidokDTO>> GetAllFuture()
        {
            var reuslt = _context.GetAsyncWszystkieGonitwyFuture();
            return await reuslt;
        }
    }
}
