using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IGraczRepository
    {
        List<Gracz> GetOneById(int id);
        List<Gracz> GetByLogin(string login);
        List<Gracz> GetAllUsersLogins();
        void DeleteUser(int id);
        bool IsCreated(string login);
        Gracz GetById(int id);
        void CanICreateUser(Gracz gracz, string password);
        void AddNewUser(Gracz gracz);
        void Update(Gracz user);


    }
}
