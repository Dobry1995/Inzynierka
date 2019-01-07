using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Services;
using AutoMapper;
using Backend.Helpers;
using Backend.DTOs;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Backend.Services.ZakladServices;
using Backend.DTOs.ZakladDtos;
using Backend.DTOs.UpdateProfileDtos;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GraczController : ControllerBase
    {
         private readonly IGraczService _serviceContext;
        private readonly IGraczZakladyService _servGZContext;

        public GraczController(IGraczService serviceContext, IGraczZakladyService servGZContext)
        {
            _serviceContext = serviceContext;
            _servGZContext = servGZContext;

        }

        //GET: api/Gracz
        [HttpGet("zaklady/{id}")]
        public async Task<IActionResult> GetZaklady(int id)
        {
            var response = new GZakladResponseDTO();
            try
            {
                response = await _servGZContext.GetAsyncLista(id);

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        
        // GET: api/Gracz|
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] GraczDTO graczDto)
        {
            return _serviceContext.AuthenticateInAction(graczDto.Login,graczDto.Haslo);
        }
       
        // GET: api/Gracz/5
        [AllowAnonymous]
        [HttpPost("register")]
        public  IActionResult Rejestracja([FromBody] GraczDTO graczDTO)
        {

            return _serviceContext.RegisterInAction(graczDTO);

        }

        // POST: api/Gracz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Gracz/update/id
        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ProfileUpdatesDTO.GraczProfil userDto)
        {
            return _serviceContext.UpdateInAction(id,userDto);
        }
        [AllowAnonymous]
        [HttpPut("update/password/{id}")]
        public IActionResult UpdateHaslo(int id, [FromBody] ProfileUpdatesDTO.GraczHaslo userDto)
        {
            return _serviceContext.UpdatePasswordInAction(id, userDto);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _serviceContext.Usuwanie(id);
        }
    }
}
