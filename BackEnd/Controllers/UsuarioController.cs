using BackEnd.Models;
using Common;
using Common.Cache;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DAL.Interface;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Constructor
        private IUsuarioBLL _usuarioBLL;


        public UsuarioController()
        {
            _usuarioBLL = new UsuarioBLLImpl();
        }
        #endregion

        #region Conversiones
        UsuarioModel Convertir(Usuario entity)
        {
            return new UsuarioModel
            {
                IdUsuario = entity.IdUsuario,
                NombreUsuario = entity.NombreUsuario,
                Correo = entity.Correo,
                Pass = entity.Pass,
                Nombre = entity.Nombre,
                PrimerApellido = entity.PrimerApellido,
                SegundoApellido = entity.SegundoApellido,
                NumeroTel = entity.NumeroTel,
                IdRol = entity.IdRol
            };
        }

        Usuario Convertir(UsuarioModel entity)
        {
            return new Usuario
            {
                IdUsuario = entity.IdUsuario,
                NombreUsuario = entity.NombreUsuario,
                Correo = entity.Correo,
                Pass = entity.Pass,
                Nombre = entity.Nombre,
                PrimerApellido = entity.PrimerApellido,
                SegundoApellido = entity.SegundoApellido,
                NumeroTel = entity.NumeroTel,
                IdRol = entity.IdRol
            };
        }
        #endregion

        #region Create
        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel entity)
        {
            try
            {
                Usuario objeto = Convertir(entity);
                objeto.Pass = Encrypt.GetSHA256(objeto.Pass); //encripta pass
                _usuarioBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<UsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Usuario> entity;
            entity = _usuarioBLL.GetAll();

            List<UsuarioModel> result = new List<UsuarioModel>();

            foreach (Usuario item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }

        [Route("GetByNameUsuario")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Usuario> entity;
            entity = _usuarioBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public JsonResult Get(int id)
        {
            Usuario entity;
            entity = _usuarioBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        [HttpPut]
        public JsonResult Put([FromBody] UsuarioModel entity)
        {
            try
            {
                entity.Pass = Encrypt.GetSHA256(entity.Pass);
                _usuarioBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Usuario entity = new Usuario { IdUsuario = id };

                _usuarioBLL.Remove(entity);
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Login
        [Route("Login")]
        [HttpPost]
        public JsonResult Log([FromBody] UsuarioModel entity)
        {
            //session = new Session();
            try
            {
                Usuario objeto = Convertir(entity);
                if (_usuarioBLL.LoginUser(objeto.NombreUsuario, objeto.Pass))
                {
                    objeto.IdUsuario = UserLoginCache.IdUsuario;
                    objeto.NombreUsuario = UserLoginCache.NombreUsuario;
                    objeto.Correo = UserLoginCache.Correo;
                    objeto.Pass = UserLoginCache.Pass;
                    objeto.Nombre = UserLoginCache.Nombre;
                    objeto.PrimerApellido = UserLoginCache.PrimerApellido;
                    objeto.SegundoApellido = UserLoginCache.SegundoApellido;
                    objeto.NumeroTel = UserLoginCache.NumeroTel;
                    objeto.IdRol = UserLoginCache.IdRol;
                    return new JsonResult(Convertir(objeto));
                }
                else
                {
                    return new JsonResult(Convertir(objeto));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
