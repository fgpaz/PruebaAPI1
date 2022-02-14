using DataAccess.CRUD;
using Models;
using Models.Exceptions;


namespace Logic
{
    public class CertificacionDevengamientoLogic
    {
        private readonly CertificacionDevengamientoCRUD _certificacionDevengamientoCRUD;
        public CertificacionDevengamientoLogic(CertificacionDevengamientoCRUD certificacionDevengamientoCRUD)
        {
            this._certificacionDevengamientoCRUD = certificacionDevengamientoCRUD;
        }

        // GET
        public async Task<List<CertificacionDevengamiento>> Get() => await _certificacionDevengamientoCRUD.Get();

        // GET/{id}
        public async Task<List<CertificacionDevengamiento>?> GetById(int id) => await _certificacionDevengamientoCRUD.GetById(id);

        // POST
        public async Task<CertificacionDevengamiento?> Create(CertificacionDevengamiento certificacionDevengamiento)
        {
            //if (GetById(certificacionDevengamiento.Id) != null)
            //{
            //    throw new ExisteTodoConElMismoNombreException
            //    {
            //        Details = "Ya existe este item",
            //        StatusCode = 400
            //    };
            //}
            //else return await _certificacionDevengamientoCRUD.Create(certificacionDevengamiento);
            return await _certificacionDevengamientoCRUD.Create(certificacionDevengamiento);
        }

        // PUT
        public async Task<CertificacionDevengamiento?> Update(CertificacionDevengamiento certificacionDevengamiento)
        {
            if (GetById(certificacionDevengamiento.Id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _certificacionDevengamientoCRUD.Create(certificacionDevengamiento);
        }

        // DELETE
        public async Task<CertificacionDevengamiento?> DeleteFisico(int id)
        {
            var certificacionDevengamiento = _certificacionDevengamientoCRUD.GetById(id);
            if (certificacionDevengamiento == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _certificacionDevengamientoCRUD.DeleteFisico(id);
        }
    }
}
