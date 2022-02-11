using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CRUD
{
    public class CertificacionDevengamientoCRUD
    {
        private readonly ContextDB _contextDB;

        public CertificacionDevengamientoCRUD(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }

        // GET
        public async Task<List<CertificacionDevengamiento>> Get()
        {
            var query = _contextDB.CertificacionDevengamientos
                            .Where(cd => cd != null)
                            .Include(cd => cd.Proyecto)
                            .Include(cd => cd.Usuario);
            return await query.ToListAsync();
        }

        // GET/{id} id es long
        public async Task<List<CertificacionDevengamiento>?> GetById(long id)
        {
            var query = _contextDB.CertificacionDevengamientos
                            .Where(cd => cd.Id == id)
                            .Include(cd => cd.Proyecto)
                            .Include(cd => cd.Usuario);
            return await query.ToListAsync();
        }

        // POST
        public async Task<CertificacionDevengamiento> Create(CertificacionDevengamiento certificacionDevengamiento)
        {
            _contextDB.CertificacionDevengamientos.Add(certificacionDevengamiento);
            await _contextDB.SaveChangesAsync();
            return certificacionDevengamiento;
        }

        // PUT
        public async Task<CertificacionDevengamiento> Update(long id, CertificacionDevengamiento certificacionDevengamiento)
        {
            _contextDB.CertificacionDevengamientos.Update(certificacionDevengamiento);
            await _contextDB.SaveChangesAsync();
            return certificacionDevengamiento;
        }

        // DELETE 
        public async Task<CertificacionDevengamiento?> DeleteFisico(long id)
        {
            var certificacionDevengamiento = await _contextDB.CertificacionDevengamientos.FindAsync(id);
            if (certificacionDevengamiento != null) _contextDB.CertificacionDevengamientos.Remove(certificacionDevengamiento);
            await _contextDB.SaveChangesAsync();
            return certificacionDevengamiento;
        }
    }
}
