using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Localidad.Interfaces;
using Localidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Localidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadRepository _localidadRepository;
        public LocalidadController(ILocalidadRepository localidadRepository)
        {
            _localidadRepository = localidadRepository;           
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<List<Pais>>> GetPais()
        {
            try
            {
                var localidad = await _localidadRepository.GetPaissAsync();
                
              return Ok(localidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Pais>> Post([FromBody] Pais pais)
        {
            try
            {
                await _localidadRepository.AddPaisAsync(pais);
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpPut]
        public async Task<ActionResult<Pais>> Put([FromBody] Pais pais)
        {
            try
            {
                await _localidadRepository.UpdatePaissAsync(pais);
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> Delete(int id)
        {
            try
            {
               var pais  =await _localidadRepository.Delete(id);
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> Get(int id)
        {
            try
            {
                var localidad = await _localidadRepository.GetPaisAsync(id);
                return localidad;
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

    }
    
}