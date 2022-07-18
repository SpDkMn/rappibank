using BancoEntity;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody] TarjetaBE Tarjeta)
        {
            TarjetaService.Save(Tarjeta);
            return Ok();
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TarjetaBE Tarjeta)
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
