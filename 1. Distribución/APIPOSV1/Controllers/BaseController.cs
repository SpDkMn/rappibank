using IntefacesNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPOSV1.Controllers
{
    [Route("pos/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IGenericoService<T> _genericoService;

        public BaseController(IGenericoService<T> genericoService)
        {
            _genericoService = genericoService;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await _genericoService.Get();
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(Guid id)
        {
            return await _genericoService.GetObj(id);
        }

        // POST api/<BaseController>
        [HttpPost]
        public async Task Post(T obj)
        {
            await _genericoService.Save(obj);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, T obj)
        {
            await _genericoService.Update(id, obj);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _genericoService.Delete(id);
        }
    }
}
