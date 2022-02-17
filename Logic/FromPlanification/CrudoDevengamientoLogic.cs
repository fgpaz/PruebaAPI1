using DataAccess.FromPlanificacion;
using Models.FromPlanificacion;

namespace Logic.FromPlanification
{
    public class CrudoDevengamientoLogic
    {
        private readonly CrudoDevengamientoAccess _crudoDevengamientoAccess;
        public CrudoDevengamientoLogic(CrudoDevengamientoAccess crudoDevengamientoAccess) 
        {
            this._crudoDevengamientoAccess = crudoDevengamientoAccess;
        }

        // GET
        public async Task<List<CrudoDevengamiento>?> Get() => await _crudoDevengamientoAccess.GetCrudoDevengamientos();
    }
}
