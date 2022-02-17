using Logic.FromPlanification;
using Microsoft.AspNetCore.Mvc;
using Models.FromPlanificacion;

namespace PruebaAPI.Controllers.FromPlanification
{
    [Route("api/[controller]")]
    [ApiController]
    public class FromPlanificationController : ControllerBase
    {
        private readonly CrudoDevengamientoLogic _crudoDevengamientoLogic;
        private readonly TargetDevengamientoLogic _targetDevengamientoLogic;
        public FromPlanificationController(CrudoDevengamientoLogic crudoDevengamientoLogic, TargetDevengamientoLogic targetDevengamientoLogic)
        {
            this._crudoDevengamientoLogic = crudoDevengamientoLogic;
            this._targetDevengamientoLogic = targetDevengamientoLogic;
        }

        // GET: api/GetCrudoDevengamiento
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<CrudoDevengamiento?>?>> GetCrudoDevengamiento()
        {            
            return await _crudoDevengamientoLogic.Get();
        }

        // GET: api/GetTargetDevengamiento
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<TargetDevengamiento?>?>> GetTargetDevengamiento()
        {
            return await _targetDevengamientoLogic.Get();
        }
    }
}
