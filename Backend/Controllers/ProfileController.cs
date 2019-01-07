using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.ProfileDtos;
using Backend.Services;
using Backend.Services.ProfileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProfileController : ControllerBase
    {
        private readonly IWierzchowiecService _service;
        private readonly IDzokejService _servDzokej;
        private readonly IGraczProfileService _servGracz;
        public ProfileController(IWierzchowiecService service, IDzokejService servDzokej, IGraczProfileService servGracz)
        {
            _servGracz = servGracz;
            _service = service;
            _servDzokej = servDzokej;
        }
        
        
        ///Gracz
        [HttpGet("GraczProfile/all")]
        public async Task<IActionResult> GetGracze()
        {
            var response = new List<ProfileDTO.GraczProfil>();
            try
            {
                response = await _servGracz.GetAll();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }

        [HttpGet("GraczProfile/{id}")]
        public async Task<IActionResult> GetGracz(int id)
        {
            var response = new ProfileDTO.GraczProfil();
            try
            {
                response = await _servGracz.GetAsyncProfile(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        
        
        //Wierzchowiec
        [HttpGet("Wierzchowiec/all")]
        public async Task<IActionResult> GetWierzch()
        {
            var response = new List<ProfileDTO.Wierzchowiec>();
            try
            {
                response = await _service.GetAllAsync();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }

        [HttpGet("Wierzchowiec/{id}")]
        public async Task<IActionResult> GetWierzch(int id)
        {
            var response = new ProfileDTO.Wierzchowiec();
            try
            {
                response = await _service.GetById(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        
        ///Dzokej
        [HttpGet("Dzokej/{id}")]
        public async Task<IActionResult> GetDzokej(int id)
        {
            var response = new ProfileDTO.DzokejProfil();
            try
            {

                response = await _servDzokej.GetAsyncProfile(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }

        [HttpGet("Dzokej/all")]
        public async Task<IActionResult> GetDzokej()
        {
            var response = new List<ProfileDTO.DzokejProfil>();
            try
            {
                response = await _servDzokej.GetAll();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }

    }
}