using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class UsuarioDA
    {
        private readonly UsuarioDB _usuarioDB;

        public UsuarioDA(UsuarioDB usuarioDB)
        {
            this._usuarioDB = usuarioDB;
        }

        // Para GET
        public async Task<List<Usuario>> Get()
        {
            //var query = _usuarioDB.Usuarios.Where(u =>
            //   u.Email.Contains("gmail"));
            //query = query.Where(u => u.Nombre.Contains("g"));
            //query = query.OrderBy(u => u.Nombre);
            //query = query.Include(u => u.Sbu);
            //return await query.ToListAsync();
            return await _usuarioDB.Usuarios.ToListAsync();

        }

        // Para GET/{id}
        public async Task<Usuario?> GetUsuario(long id)
        {
            var usuario = _usuarioDB.Usuarios.FindAsync(id);
            return await usuario;
        }

        // Para POST
        public async Task<Usuario> Create(Usuario usuario)
        {
            _usuarioDB.Usuarios.Add(usuario);
            await _usuarioDB.SaveChangesAsync();
            return usuario;
        }

        // Para PUT
        public async Task<Usuario> Update(long id, Usuario usuario)
        {
            //_todoDb.Entry(todoItem).State = EntityState.Modified;
            _usuarioDB.Usuarios.Update(usuario);
            await _usuarioDB.SaveChangesAsync();
            return usuario;
        }

        // Delete fisico
        public async Task<Usuario?> DeleteUsuario(long id)
        {
            var usuario = await GetUsuario(id);
            if (usuario != null) _usuarioDB.Usuarios.Remove(usuario);
            await _usuarioDB.SaveChangesAsync();
            return usuario;
        }
    }
}
