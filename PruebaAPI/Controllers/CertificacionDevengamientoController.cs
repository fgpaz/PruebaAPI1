using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificacionDevengamientoController : ControllerBase
    {
        private readonly CertificacionDevengamientoLogic _certificacionDevengamientoLogic;
        private readonly LoggerService _loggerService;
        public CertificacionDevengamientoController(CertificacionDevengamientoLogic certificacionDevengamientoLogic, LoggerService loggerService) 
        {
            this._certificacionDevengamientoLogic = certificacionDevengamientoLogic;
            this._loggerService = loggerService;
        }

        // GET: api/CertificacionDevengamiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificacionDevengamiento?>>> Get() 
        {
            _loggerService.Info("Obteniendo Certificacion de Devengamiento");
            return await _certificacionDevengamientoLogic.Get(); 
        }

        // Get: api/CertificacionDevengamiento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CertificacionDevengamiento>?>> GetById(int id) 
        {
            try
            {
                return await _certificacionDevengamientoLogic.GetById(id);
            }
            catch (CustomException ce) 
            {
                return new ObjectResult(new { ce.Details }) { StatusCode = ce.StatusCode };
            }
        }

        // POST: api/CertificacionDevengamiento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificacionDevengamiento?>> Post(CertificacionDevengamiento certificacionDevengamiento)
        {
            try
            {
                return await _certificacionDevengamientoLogic.Create(certificacionDevengamiento);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // PUT: api/CertificacionDevengamiento/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CertificacionDevengamiento?>> Put([FromRoute] long id, [FromBody] CertificacionDevengamiento certificacionDevengamiento)
        {
            try
            {
                return await _certificacionDevengamientoLogic.Update(certificacionDevengamiento);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // DELETE: api/CertificacionDevengamiento/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CertificacionDevengamiento>?>> Delete([FromRoute] int id)
        {
            try
            {
                var certificacionDevengamiento = _certificacionDevengamientoLogic.GetById(id);
                await _certificacionDevengamientoLogic.DeleteFisico(id);
                return await certificacionDevengamiento;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }
    }
}
