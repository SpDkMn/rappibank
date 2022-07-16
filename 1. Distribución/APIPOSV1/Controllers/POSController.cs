using Microsoft.AspNetCore.Mvc;
using POSEntity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPOSV1.Controllers
{
    [Route("pos/api/v1/[controller]")]
    [ApiController]
    public class POSController : ControllerBase
    {
        // POST api/<POSController>
        [HttpPost]
        public void Post([FromBody] Transaccion value)
        {
        }
    }
}
