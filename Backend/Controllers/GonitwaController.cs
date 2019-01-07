using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ZakladDtos;
using Backend.Services.ProfileServices;
using Backend.Services.ZakladServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GonitwaController : ControllerBase
    {
        private readonly ISzczegolyGonitwyService _loginServ;
        private readonly IGonitwaService _goniServ;
        public GonitwaController(ISzczegolyGonitwyService loginServ, IGonitwaService goniServ)
        {
            _loginServ = loginServ;
            _goniServ = goniServ;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = new List<GonitwyWidokDTO>();
            try
            {
                response = await _goniServ.GetAll();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        [HttpGet("all/future")]
        public async Task<IActionResult> GetFuture()
        {
            var response = new List<GonitwyWidokDTO>();
            try
            {
                response = await _goniServ.GetAllFuture();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new GonitwaListaDTO();
            try
            {
                response = await _loginServ.GetAsync(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }

        [HttpGet("Szczegoly/{id}")]
        public async Task<IActionResult> GetSzczegoly(int id)
        {
            var response = new GonitwaListaDTO.SzczegolyGonitwys();
            try
            {
                response = await _loginServ.GetAsyncSzczegoly(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
    }
}