using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioLogic _usuarioLogic;
        private readonly LoggerService _loggerService;
        public UsuarioController(UsuarioLogic usuarioLogic, LoggerService loggerService) 
        {
            this._usuarioLogic = usuarioLogic;
            this._loggerService = loggerService;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario?>>> GetUsuarios() 
        {
            _loggerService.Info("Obteniendo usuario");
            return await _usuarioLogic.Get(); 
        }

        // Get: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario?>> GetUsuario(long id) 
        {
            try
            {
                return await _usuarioLogic.GetUsuario(id);
            }
            catch (CustomException ce) 
            {
                return new ObjectResult(new { ce.Details }) { StatusCode = ce.StatusCode };
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario?>> PostUsuario(Usuario usuario)
        {
            try
            {
                return await _usuarioLogic.Create(usuario);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // PUT: api/Usuario/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario?>> PutUsuario([FromRoute] long id, [FromBody] Usuario usuario)
        {
            try
            {
                return await _usuarioLogic.Update(id, usuario);
                //todoItem;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario?>> DeleteUsuario([FromRoute] long id)
        {
            try
            {
                var usuario = _usuarioLogic.GetUsuario(id);
                await _usuarioLogic.DeleteUsuario(id);
                return await usuario;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }
    }
}
