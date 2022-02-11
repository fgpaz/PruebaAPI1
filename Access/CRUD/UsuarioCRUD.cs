using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class UsuarioCRUD
    {
        private readonly ContextDB _contextDB;

        public UsuarioCRUD(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }

        // Para GET
        public async Task<List<Usuario>> Get()
        {
            //var query = _contextDB.Usuarios.Where(u =>
            //   u.Email.Contains("gmail"));
            //query = query.Where(u => u.Nombre.Contains("g"));
            //query = query.OrderBy(u => u.Nombre);
            //query = query.Include(u => u.Sbu);
            //return await query.ToListAsync();
            return await _contextDB.Usuarios.ToListAsync();

        }

        // Para GET/{id}
        public async Task<Usuario?> GetById(long id)
        {
            var usuario = _contextDB.Usuarios.FindAsync(id);
            return await usuario;
        }

        // Para POST
        public async Task<Usuario> Create(Usuario usuario)
        {
            _contextDB.Usuarios.Add(usuario);
            await _contextDB.SaveChangesAsync();
            return usuario;
        }

        // Para PUT
        public async Task<Usuario> Update(long id, Usuario usuario)
        {
            //_todoDb.Entry(todoItem).State = EntityState.Modified;
            _contextDB.Usuarios.Update(usuario);
            await _contextDB.SaveChangesAsync();
            return usuario;
        }

        // DELETE fisico
        public async Task<Usuario?> DeleteFisico(long id)
        {
            var usuario = await GetById(id);
            if (usuario != null) _contextDB.Usuarios.Remove(usuario);
            await _contextDB.SaveChangesAsync();
            return usuario;
        }
    }
}
