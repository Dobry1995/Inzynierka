using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaStartowaController : ControllerBase
    {
        private readonly IListaStartowaService _loginServ;
        public ListaStartowaController(IListaStartowaService loginServ)
        {
            _loginServ = loginServ;
        }
        [HttpGet("lista-wyscigu/{id}")]
        public async Task<IActionResult> GetLista(int id)
        {
            var response = new List<ListaWyscigowDTO.ListaStartowas>();
            try
            {
                response = await _loginServ.GetAsyncListaWysciguById(id);
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
            var response = new GraczZakladResponse();
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
    }
}