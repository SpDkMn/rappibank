﻿using Entidades;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBANCOV1.Controllers
{
    [Route("banco/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService UsuarioService;
        public UsuarioController(IUsuarioService service)
        {
            UsuarioService = service;
        }
        // GET: api/v1/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UsuarioService.Get());
        }

        // GET api/v1/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(UsuarioService.GetUsuario(id));
        }

        // POST api/v1/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            UsuarioService.Save(Usuario);
            return Ok();
        }

        // PUT api/v1/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario Usuario)
        {
            UsuarioService.Update(id, Usuario);
            return Ok();
        }

        // DELETE api/v1/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            UsuarioService.Delete(id);
            return Ok();
        }
    }
}
