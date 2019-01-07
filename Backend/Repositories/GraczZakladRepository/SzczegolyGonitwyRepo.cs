using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ZakladDtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using static Backend.DTOs.ZakladDtos.GonitwaListaDTO;

namespace Backend.Repositories.GraczZakladRepository
{
    public class SzczegolyGonitwyRepo : ISzczegolyGonitwyRepo
    {
        private readonly TotalizatorContext _context;
        public SzczegolyGonitwyRepo(TotalizatorContext context)
        {
            _context=context;
        }
        public async Task<GonitwaListaDTO> GetAsyncListaWyscigu(int id)
        {
            return await _context.Gonitwa
                .Where(s => s.NrGonitwyWSezonie == id)
                .Select(l => new GonitwaListaDTO()
                {
                    NrGonitwyWSezonie = l.NrGonitwyWSezonie,
                    NrGonitwyWDniu = l.NrGonitwyWDniu,
                    ListaStartowa =l.ListaStartowa.Where(p=>p.NrGonitwyWSezonie==l.NrGonitwyWSezonie).Select(c=>new ListaStartowas
                    {
                        NrWierzchowca=c.NrWierzchowcaNavigation.NrWierzchowca,
                        NazwaWierzchowca=c.NrWierzchowcaNavigation.NazwaWierzchowca,
                        NrDzokeja=c.NrDzokejaNavigation.NrDzokej,
                        Imie=c.NrDzokejaNavigation.Imie,
                        Nazwisko=c.NrDzokejaNavigation.Nazwisko
                        
                    }).ToList()
                }).SingleOrDefaultAsync();
        }

        public async Task<GonitwaListaDTO.SzczegolyGonitwys> GetAsyncSzczegolyWyscigu(int id)
        {
            return await _context.Gonitwa
                .Where(s => s.NrGonitwyWSezonie==id).Select(l => new SzczegolyGonitwys()
                {
                 NazwaNagrody=l.NrSzczegolyNavigation.NazwaNagrody,
                 WarunkiGonitwy=l.NrSzczegolyNavigation.WarunkiGonitwy,
                 Data=l.NrSzczegolyNavigation.Data,
                 GodzinaRozpoczecia=l.NrSzczegolyNavigation.GodzinaRozpoczecia,
                 Dlugosc=l.NrSzczegolyNavigation.Dlugosc,
                 NagrodaZaIMiejsce=l.NrSzczegolyNavigation.NagrodaZaIMiejsce,
                 NagrodaZaIiMiejsce=l.NrSzczegolyNavigation.NagrodaZaIiMiejsce,
                 NagrodaZaIiiMiejsce=l.NrSzczegolyNavigation.NagrodaZaIiiMiejsce,
                 NagrodaZaIvMiejsce=l.NrSzczegolyNavigation.NagrodaZaIvMiejsce,
                 NagrodaZaVMiejsce=l.NrSzczegolyNavigation.NagrodaZaVMiejsce
                 

                }).SingleOrDefaultAsync();
        }
    }
}
