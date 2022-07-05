using Entidades;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBANCOV1.Controllers
{
    [Route("banco/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController :ControllerBase
    {
        ICuentaService CuentaService;
        public CuentaController(ICuentaService service)
        {
            CuentaService = service;
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CuentaService.Get());
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(CuentaService.GetCuenta(id));
        }

        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult Post([FromBody] Cuenta Cuenta)
        {
            CuentaService.Save(Cuenta);
            return Ok();
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Cuenta Cuenta)
        {
            CuentaService.Update(id, Cuenta);
            return Ok();
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            CuentaService.Delete(id);
            return Ok();
        }
    }
}
