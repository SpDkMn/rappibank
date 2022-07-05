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
    public class TarjetaController : ControllerBase
    {
        ITarjetaService TarjetaService;
        public TarjetaController(ITarjetaService service)
        {
            TarjetaService = service;
        }
        // GET: api/<TarjetaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TarjetaService.Get());
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(TarjetaService.GetTarjeta(id));
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public IActionResult Post([FromBody] Tarjeta Tarjeta)
        {
            TarjetaService.Save(Tarjeta);
            return Ok();
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarjeta Tarjeta)
        {
            TarjetaService.Update(id, Tarjeta);
            return Ok();
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            TarjetaService.Delete(id);
            return Ok();
        }
    }
}
