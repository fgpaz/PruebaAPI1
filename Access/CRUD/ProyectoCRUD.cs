using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.CRUD
{
    public class ProyectoCRUD
    {
        public readonly ContextDB _contextDB;
        public ProyectoCRUD(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }

        // GET
        public async Task<List<Proyecto>> Get()
        {
            return await _contextDB.Proyectos.ToListAsync();
        }

        // GET/{id} id es string
        public async Task<Proyecto?> GetById(string id)
        {
            var proyecto = _contextDB.Proyectos.FindAsync(id);
            return await proyecto;
        }

        // POST
        public async Task<Proyecto> Create(Proyecto proyecto)
        {
            _contextDB.Proyectos.Add(proyecto);
            await _contextDB.SaveChangesAsync();
            return proyecto;
        }

        // PUT
        public async Task<Proyecto> Update(string id, Proyecto proyecto)
        {
            _contextDB.Proyectos.Update(proyecto);
            await _contextDB.SaveChangesAsync();
            return proyecto;
        }

        // DELETE fisico
        public async Task<Proyecto?> DeleteFisico(string id)
        {
            var proyecto = await GetById(id);
            if (proyecto != null) _contextDB.Proyectos.Remove(proyecto);
            await _contextDB.SaveChangesAsync();
            return proyecto;
        }
    }
}
