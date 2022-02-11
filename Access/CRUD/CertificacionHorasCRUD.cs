using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CRUD
{
    public class CertificacionHorasCRUD
    {
        private readonly ContextDB _contextDB;
        public CertificacionHorasCRUD(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }

        // GET
        public async Task<List<CertificacionHoras>> Get() 
        {
            var query = _contextDB.CertificacionHoras
                            .Where(ch => ch != null)
                            .Include(ch => ch.Proyecto)
                            .Include(ch => ch.Usuario);
            return await query.ToListAsync();
        }

        // GET/{id} id es long
        public async Task<List<CertificacionHoras>?> GetById(long id)
        {
            var query = _contextDB.CertificacionHoras
               .Where(ch => ch.Id == id)
               .Include(ch => ch.Proyecto)
               .Include(ch => ch.Usuario);
            return await query.ToListAsync();
        }

        // POST
        public async Task<CertificacionHoras> Create(CertificacionHoras certificacionHoras)
        {
            _contextDB.CertificacionHoras.Add(certificacionHoras);
            await _contextDB.SaveChangesAsync();
            return certificacionHoras;
        }

        // POST
        public async Task<CertificacionHoras?> Update(long id, CertificacionHoras certificacionHoras)
        {
            _contextDB.CertificacionHoras.Update(certificacionHoras);
            await _contextDB.SaveChangesAsync();
            return certificacionHoras;
        }

        // DELETE fisico
        public async Task<CertificacionHoras?> DeleteFisico(long id)
        {
            var certificacionHoras = await _contextDB.CertificacionHoras.FindAsync(id);
            if (certificacionHoras != null) _contextDB.CertificacionHoras.Remove(certificacionHoras);
            await _contextDB.SaveChangesAsync();
            return certificacionHoras;
        }
    }
}
