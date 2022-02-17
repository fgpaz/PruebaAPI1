using DataAccess.FromPlanificacion;
using Models.FromPlanificacion;

namespace Logic.FromPlanification
{
    public class TargetDevengamientoLogic
    {
        private readonly TargetDevengamientoAccess _targetDevengamientoAccess;
        public TargetDevengamientoLogic(TargetDevengamientoAccess targetDevengamientoAccess)
        {
            this._targetDevengamientoAccess = targetDevengamientoAccess;
        }

        // GET
        public async Task<List<TargetDevengamiento>?> Get() => await _targetDevengamientoAccess.GetTargetDevengamientos();
    }
}
