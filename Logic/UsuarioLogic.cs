using DataAccess;
using Models;
using Models.Exceptions;

namespace Logic
{
    public class UsuarioLogic
    {
        private readonly UsuarioCRUD _usuarioDA;
        public UsuarioLogic(UsuarioCRUD usuarioDA)
        {
            this._usuarioDA = usuarioDA;
        }

        // GET
        public async Task<List<Usuario>> Get() => await _usuarioDA.Get();

        // GET/{id}
        public async Task<Usuario?> GetByID(long id) => await _usuarioDA.GetById(id);

        // POST
        public async Task<Usuario?> Create(Usuario usuario)
        {
            if (await siExisteElItem(usuario))
            {
                throw new ExisteTodoConElMismoNombreException
                {
                    Details = "Ya existe este item",
                    StatusCode = 400
                };
            }
            else return await _usuarioDA.Create(usuario);
        }

        // PUT
        public async Task<Usuario> Update(long id, Usuario usuario)
        {
            if (_usuarioDA.GetById(id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else
            {
                return await _usuarioDA.Update(id, usuario);
            }
        }

        // Para DELETE
        public async Task<Usuario?> DeleteUsuario(long id)
        {
            var usuario = _usuarioDA.GetById(id);
            if (usuario == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else
            {
                await _usuarioDA.DeleteFisico(id);
            }
            return await usuario;
        }

        // VALIDACIONES
        private async Task<bool> siExisteElItem(Usuario? usuario)
        {
            var listadoTodoItem = _usuarioDA.Get();
            var siExiste = false;
            foreach (var item in await listadoTodoItem)
            {
                if (usuario != null && item.Id == usuario.Id) siExiste = true;
            }
            return siExiste;
        }        
    }
}
