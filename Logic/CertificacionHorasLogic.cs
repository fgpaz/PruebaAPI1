using DataAccess.CRUD;
using Models;
using Models.Exceptions;

namespace Logic
{
    public class CertificacionHorasLogic
    {
        private readonly CertificacionHorasCRUD _certificacionHorasCRUD;
        public CertificacionHorasLogic(CertificacionHorasCRUD certificacionHorasCRUD)
        {
            this._certificacionHorasCRUD = certificacionHorasCRUD;
        }

        // GET
        public async Task<List<CertificacionHoras>> Get() => await _certificacionHorasCRUD.Get();

        // GET/{id}
        public async Task<List<CertificacionHoras>> GetById(int id) => await _certificacionHorasCRUD.GetById(id);

        // POST
        public async Task<CertificacionHoras> Create(CertificacionHoras certificacionHoras)
        {
            if (GetById(certificacionHoras.Id) != null)
            {
                throw new ExisteTodoConElMismoNombreException
                {
                    Details = "Ya existe este item",
                    StatusCode = 400
                };
            }
            else return await _certificacionHorasCRUD.Create(certificacionHoras);
        }

        // PUT
        public async Task<CertificacionHoras?> Update(int id, CertificacionHoras certificacionHoras)
        {
            if (GetById(certificacionHoras.Id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _certificacionHorasCRUD.Create(certificacionHoras);
        }

        // DELETE
        public async Task<CertificacionHoras?> Delete(int id)
        {
            var certificacionHoras = _certificacionHorasCRUD.GetById(id);
            if (certificacionHoras == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else return await _certificacionHorasCRUD.DeleteFisico(id);
        }
    }
}

