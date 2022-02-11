using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificacionHorasController : ControllerBase
    {
        private readonly CertificacionHorasLogic _certificacionHorasLogic ;
        private readonly LoggerService _loggerService;
        public CertificacionHorasController(CertificacionHorasLogic certificacionHorasLogic, LoggerService loggerService) 
        {
            this._certificacionHorasLogic = certificacionHorasLogic;
            this._loggerService = loggerService;
        }

        // GET: api/CertificacionHoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificacionHoras?>>> Get() 
        {
            _loggerService.Info("Obteniendo certificacion de horas");
            return await _certificacionHorasLogic.Get(); 
        }

        // Get: api/CertificacionHoras/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CertificacionHoras>?>> GetById(int id) 
        {
            try
            {
                return await _certificacionHorasLogic.GetById(id);
            }
            catch (CustomException ce) 
            {
                return new ObjectResult(new { ce.Details }) { StatusCode = ce.StatusCode };
            }
        }

        // POST: api/CertificacionHoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificacionHoras?>> Post(CertificacionHoras certificacionHoras)
        {
            try
            {
                return await _certificacionHorasLogic.Create(certificacionHoras);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // PUT: api/CertificacionHoras/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CertificacionHoras?>> Put([FromRoute] long id, [FromBody] CertificacionHoras certificacionHoras)
        {
            try
            {
                return await _certificacionHorasLogic.Update(certificacionHoras);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // DELETE: api/CertificacionHoras/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CertificacionHoras>?>> Delete([FromRoute] int id)
        {
            try
            {
                var certificacionHoras = _certificacionHorasLogic.GetById(id);
                await _certificacionHorasLogic.DeleteFisico(id);
                return await certificacionHoras;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }
    }
}
