using AutoMapper;
using Backend.DTOs;
using Backend.DTOs.UpdateProfileDtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class GraczService : ControllerBase, IGraczService
    {
        private readonly IGraczRepository _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSetter;

        public GraczService(IGraczRepository context, IMapper mapper, IOptions <AppSettings> appSetter)
        {
            _context = context;
            _mapper = mapper;
            _appSetter = appSetter.Value;
        }
        public Gracz Authenticate(string login, string haslo)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
                return null;

            var user = _context.GetByLogin(login).FirstOrDefault();
            //sprawdzanie czy jest taki gracz

            if (user == null)
                return null;
            //Weryfikacja hasła
            if (!WeryfikacjaHashHasla(haslo, user.HashHaslo, user.SaltHaslo))
                return null;
            //udana autentykacja
            return user;

        }
        public IActionResult AuthenticateInAction(string Login, string Haslo)
        {
            var user = Authenticate(Login, Haslo);
            if (user == null)
                return BadRequest(new { message = "Login lub haslo jest niepoprawne" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetter.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name,user.IdGracza.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);
            //zwrot podstawowych info bez hasla
            return Ok(new
            {
                Id = user.IdGracza,
                Login = user.Login,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Rola=user.Rola,
                Token = tokenString
            });
        }

        public IActionResult RegisterInAction(GraczDTO graczDTO)
        {
            var user = _mapper.Map<Gracz>(graczDTO);
            try
            {
                Stworz(user, graczDTO.Haslo);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        public IActionResult UpdateInAction(int id, ProfileUpdatesDTO.GraczProfil graczDTO)
        {
            var user = _mapper.Map<Gracz>(graczDTO);
            user.IdGracza = id;
           try
            {
                Aktualizacja(user, graczDTO.Haslo);
                return Ok();     
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        public IActionResult UpdatePasswordInAction(int id, ProfileUpdatesDTO.GraczHaslo graczDTO)
        {
            var user = _mapper.Map<Gracz>(graczDTO);
            user.IdGracza = id;
            try
            {
                AktualizacjaHasla(user, graczDTO.Haslo);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        public void Usuwanie(int id)
        {
            _context.DeleteUser(id);

        }

        public Gracz PodajJednegoPoId(int id)
        {
            return _context.GetById(id);
        }

        public List<Gracz> PodajWszystkich()
        {
            return _context.GetAllUsersLogins();
        }

        public Gracz Stworz(Gracz gracz, string haslo)
        {
            _context.CanICreateUser(gracz, haslo);

            byte[] hashHaslo, saltHaslo;
            TworzenieHashHasla(haslo, out hashHaslo, out saltHaslo);

            gracz.HashHaslo = hashHaslo;
            gracz.SaltHaslo = saltHaslo;

            _context.AddNewUser(gracz);

            return gracz;
        }

        public void TworzenieHashHasla(string haslo, out byte[] HashHaslo, out byte[] SaltHaslo)
        {
            if (haslo == null)
                throw new ArgumentNullException("haslo");
            if (string.IsNullOrWhiteSpace(haslo))
                throw new ArgumentException("Haslo nie może być puste albo zawierać specjalnych znaków", "haslo");
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                SaltHaslo = hmac.Key;
                HashHaslo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(haslo));
            }
        }

        public void Aktualizacja(Gracz graczParam, string haslo = null)
        {
            var gracz = _context.GetById(graczParam.IdGracza);
            if (gracz == null)
                throw new AppException("Gracz nie znaleziony");
            if (graczParam.Login != gracz.Login)
            {
                if (_context.IsCreated(graczParam.Login))
                    throw new AppException("Login \"" + gracz.Login + "jest zajęty");
            }
            //aktualizacja
            gracz.Imie = graczParam.Imie;
            gracz.Nazwisko = graczParam.Nazwisko;
            gracz.Email = graczParam.Email;
            gracz.Wiek = graczParam.Wiek;
            gracz.Wyksztalcenie = graczParam.Wyksztalcenie;
            gracz.Login = graczParam.Login;

           // aktualizacja hasła
            if (!string.IsNullOrWhiteSpace(haslo))
            {
                byte[] HashHaslo, SaltHaslo;
                TworzenieHashHasla(haslo, out HashHaslo, out SaltHaslo);
                gracz.HashHaslo = HashHaslo;
                gracz.SaltHaslo = SaltHaslo;

            }
            _context.Update(gracz);

        }
        public void AktualizacjaHasla(Gracz paramgracz, string haslo)
        {
            var gracz = _context.GetById(paramgracz.IdGracza);
            if (!string.IsNullOrWhiteSpace(haslo))
            {
                byte[] HashHaslo, SaltHaslo;
                TworzenieHashHasla(haslo, out HashHaslo, out SaltHaslo);
                gracz.HashHaslo = HashHaslo;
                gracz.SaltHaslo = SaltHaslo;

            }
            _context.Update(gracz);
        }

        public bool WeryfikacjaHashHasla(string haslo, byte[] storedHash, byte[] storedSalt)
            {
                if (haslo == null)
                    throw new ArgumentException("haslo");
                if (string.IsNullOrWhiteSpace(haslo))
                    throw new ArgumentException("Haslo nie może być puste albo zawierać specjalnych znaków", "haslo");
                if (storedHash.Length != 64)
                    throw new ArgumentException("Nieprawidłowa długość hash hasła(64 wymagane)", "haslo");
                if (storedSalt.Length != 128)
                    throw new ArgumentException("Niepoprawna długość Salt hasla(128 wymagane)", "haslo");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(haslo));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != storedHash[i])
                            return false;
                    }
                }
                return true;
            }
    }
}
