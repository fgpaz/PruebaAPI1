using Microsoft.Extensions.Configuration;
using Models.FromPlanificacion;

namespace DataAccess.FromPlanificacion
{
    public class TargetDevengamientoAccess : DatosCrudosAccess
    {
        public TargetDevengamientoAccess(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<TargetDevengamiento>?> GetTargetDevengamientos()
            => await Get<List<TargetDevengamiento>>("/TargetDevengamiento");
    }
}
