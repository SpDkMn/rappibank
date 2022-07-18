using BancoEntity;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIBANCOV1.Controllers
{
    [Route("banco/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientoController : ControllerBase
    {
        IMovimientoService MovimientoService;
        public MovimientoController(IMovimientoService service)
        {
            MovimientoService = service;
        }
        // GET: api/<MovimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MovimientoService.Get());
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(MovimientoService.GetMovimiento(id));
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public IActionResult Post([FromBody] MovimientoBE Movimiento)
        {
            MovimientoService.Save(Movimiento);
            return Ok();
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MovimientoBE Movimiento)
        {
            MovimientoService.Update(id, Movimiento);
            return Ok();
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            MovimientoService.Delete(id);
            return Ok();
        }
    }
}
