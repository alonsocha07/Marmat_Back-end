using BackEnd.Models;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        #region Constructor
        private IEstadoBLL _estadoBLL;
        public EstadoController()
        {
            _estadoBLL = new EstadoBLLImpl();
        }
        #endregion

        #region Conversiones
        EstadoModel Convertir(Estado entity)
        {
            return new EstadoModel
            {
                IdEstado = entity.IdEstado,
                NombreEstado = entity.NombreEstado
            };
        }

        Estado Convertir(EstadoModel entity)
        {
            return new Estado
            {
                IdEstado = entity.IdEstado,
                NombreEstado = entity.NombreEstado
            };
        }
        #endregion

        #region Create
        // POST api/<EstadoController>
        [HttpPost]
        public JsonResult Post([FromBody] EstadoModel entity)
        {
            try
            {
                Estado objeto = Convertir(entity);
                _estadoBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<EstadoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Estado> entity;
            entity = _estadoBLL.GetAll();

            List<EstadoModel> result = new List<EstadoModel>();

            foreach (Estado item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameEstado")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Estado> entity;
            entity = _estadoBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}", Name = "GetEstado")]
        public JsonResult Get(int id)
        {
            Estado entity;
            entity = _estadoBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<EstadoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EstadoModel entity)
        {
            try
            {
                _estadoBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Estado entity = new Estado { IdEstado = id };

                _estadoBLL.Remove(entity);
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
