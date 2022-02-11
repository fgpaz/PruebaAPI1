using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoLogic _proyectoLogic;
        private readonly LoggerService _loggerService;
        public ProyectoController(ProyectoLogic proyectoLogic, LoggerService loggerService) 
        {
            this._proyectoLogic = proyectoLogic;
            this._loggerService = loggerService;
        }

        // GET: api/Proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto?>>> Get() 
        {
            _loggerService.Info("Obteniendo proyecto");
            return await _proyectoLogic.Get(); 
        }

        // Get: api/Proyecto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto?>> GetById(string id) 
        {
            try
            {
                return await _proyectoLogic.GetById(id);
            }
            catch (CustomException ce) 
            {
                return new ObjectResult(new { ce.Details }) { StatusCode = ce.StatusCode };
            }
        }

        // POST: api/Proyecto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyecto?>> Post(Proyecto proyecto)
        {
            try
            {
                return await _proyectoLogic.Create(proyecto);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // PUT: api/Proyecto/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Proyecto?>> Put([FromRoute] string id, [FromBody] Proyecto proyecto)
        {
            try
            {
                return await _proyectoLogic.Update(id, proyecto);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // DELETE: api/Proyecto/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyecto?>> Delete([FromRoute] string id)
        {
            try
            {
                var proyecto = _proyectoLogic.GetById(id);
                await _proyectoLogic.DeleteFisico(id);
                return await proyecto;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }
    }
}
