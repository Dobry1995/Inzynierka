using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repositories
{
    public class GraczRepository : IGraczRepository
    {

        private readonly TotalizatorContext _context;

        public GraczRepository(TotalizatorContext context)
        {
            _context = context;
        }

        public void AddNewUser(Gracz gracz)
        {
            _context.Gracz.Add(gracz);
            _context.SaveChanges();
        }

        public void CanICreateUser(Gracz gracz, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Haslo jest wymagane.");
            if (_context.Gracz.Any(s => s.Login == gracz.Login))
                throw new AppException("Login \""+ gracz.Login+ "\" jest zajety");
        }
        public void DeleteUser(int id)
        {
            var user = _context.Gracz.Find(id);
            if (user != null)
            {
                _context.Gracz.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Gracz> GetAllUsersLogins()
        {
            return _context.Gracz
                .OrderBy(s => s.IdGracza)
                .ToList();
        }

        public Gracz GetById(int id)
        {
            return _context.Gracz
                .Find(id);
        }

        public List<Gracz> GetByLogin(string login)
        {
            return _context.Gracz
                .Where(s => s.Login == login)
                .OrderBy(s => s.IdGracza)
                .ToList();
        }

        public List<Gracz> GetOneById(int id)
        {
            return _context.Gracz
                 .Where(s => s.IdGracza == id)
                 .ToList();

        }
        public bool IsCreated(string login)
        {
            bool exist = true;
            var user = _context.Gracz.Any(s => s.Login == login);

            if (!user)
                exist = false;

            return exist;

        }
        public  void Update(Gracz gracz)
        {
             _context.Gracz.Update(gracz);
             _context.SaveChanges();
            
        }
    }
}
