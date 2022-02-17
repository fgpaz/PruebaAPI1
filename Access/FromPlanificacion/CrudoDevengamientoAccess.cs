using Microsoft.Extensions.Configuration;
using Models.FromPlanificacion;

namespace DataAccess.FromPlanificacion
{
    public class CrudoDevengamientoAccess : DatosCrudosAccess
    {
        public CrudoDevengamientoAccess(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<CrudoDevengamiento>?> GetCrudoDevengamientos()
            => await Get<List<CrudoDevengamiento>>("/CrudoDevengamiento");
    }
}
