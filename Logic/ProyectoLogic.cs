using DataAccess;
using DataAccess.CRUD;
using Models;
using Models.Exceptions;


namespace Logic
{
    public class ProyectoLogic
    {
        private readonly ProyectoCRUD _proyectoCRUD;
        public ProyectoLogic(ProyectoCRUD proyectoCRUD)
        {
            this._proyectoCRUD = proyectoCRUD;
        }

        // GET
        public async Task<List<Proyecto>> Get() => await _proyectoCRUD.Get();

        // GET/{id}
        public async Task<Proyecto?> GetById(string id) => await _proyectoCRUD.GetById(id);

        // POST
        public async Task<Proyecto> Create(Proyecto proyecto)
        {
            if (GetById(proyecto.Id) != null)
            {
                throw new ExisteTodoConElMismoNombreException
                {
                    Details = "Ya existe este item",
                    StatusCode = 400
                };
            }
            else return await _proyectoCRUD.Create(proyecto);
        }

        // PUT
        public async Task<Proyecto?> Update(string id, Proyecto proyecto)
        {
            if (GetById(proyecto.Id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _proyectoCRUD.Create(proyecto);
        }

        // DELETE
        public async Task<Proyecto?> DeleteFisico(string id)
        {
            var proyecto = _proyectoCRUD.GetById(id);
            if (proyecto == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _proyectoCRUD.DeleteFisico(id);
        }
    }
}
