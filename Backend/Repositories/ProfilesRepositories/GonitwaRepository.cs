using Backend.DTOs.ZakladDtos;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class GonitwaRepository :  IGonitwaRepository

    {
        private readonly TotalizatorContext _context;
        private readonly DateTime todayDate = DateTime.Now.Date;
        private readonly string todayTime = DateTime.Now.ToString("HH:mm:ss");
        public GonitwaRepository(TotalizatorContext context)
        {
            _context = context;
        }
        public async Task<List<GonitwyWidokDTO>> GetAsyncWszystkieGonitwyFuture()
        {
            return await _context.Gonitwa
                .Where(s => s.NrSzczegolyNavigation.Data > todayDate)
                .Select(l => new GonitwyWidokDTO()
                {
                    NrGonitwyWDniu = l.NrGonitwyWDniu,
                    NrGonitwyWSezonie = l.NrGonitwyWSezonie,
                    Data = l.NrSzczegolyNavigation.Data,
                    GodzinaRozpoczecia = l.NrSzczegolyNavigation.GodzinaRozpoczecia,
                    NazwaNagrody = l.NrSzczegolyNavigation.NazwaNagrody,
                    Dlugosc = l.NrSzczegolyNavigation.Dlugosc
                }).ToListAsync();
        }
        public async Task<List<GonitwyWidokDTO>> GetAsyncWszystkieGonitwy()
        {
            return await _context.Gonitwa.Where(s => s.NrSzczegolyNavigation.Data < todayDate).Select(l => new GonitwyWidokDTO()
            {
                NrGonitwyWDniu = l.NrGonitwyWDniu,
                NrGonitwyWSezonie = l.NrGonitwyWSezonie,
                Data = l.NrSzczegolyNavigation.Data,
                GodzinaRozpoczecia = l.NrSzczegolyNavigation.GodzinaRozpoczecia,
                NazwaNagrody = l.NrSzczegolyNavigation.NazwaNagrody,
                Dlugosc = l.NrSzczegolyNavigation.Dlugosc
            }).ToListAsync();
        }

        public IActionResult PokazListeStartowaDanejGonitwy(int nrGonitwy)
        {
            throw new NotImplementedException();
        }

        public IActionResult PokazSzczegolyDanejGonitwy(int nrGonitwy)
        {
            throw new NotImplementedException();
        }
    }
}
