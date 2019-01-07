using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ZakladDtos;
using Backend.Services.ZakladServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraczZakladController : ControllerBase
    {
        private readonly IGraczZakladyService _loginServ;
        public GraczZakladController(IGraczZakladyService loginServ)
        {
            _loginServ = loginServ;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new GZakladResponseDTO();
            try
            {
                response = await _loginServ.GetAsyncLista(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
    }
}