using Contexto;
using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSEntity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPOSV1.Controllers
{
    [Route("pos/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class POSController : ControllerBase
    {
        ITransaccionPOSService TransaccionPOSService;
        public POSController(ITransaccionPOSService service)
        {
            TransaccionPOSService = service;
        }
        // POST api/<POSController>
        [HttpPost]
        public IActionResult Post([FromBody] TransaccionPOSBE value)
        {
            var flag = TransaccionPOSService.Save(value);
            flag.Wait();
            if (flag.Result)
            {
                return Ok(); 
            }
            return BadRequest();
        }
    }
}
