using BancoEntity;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody] CuentaBE Cuenta)
        {
            CuentaService.Save(Cuenta);
            return Ok();
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CuentaBE Cuenta)
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
