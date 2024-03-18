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
    public class DireccionController : ControllerBase
    {
        #region Constructor
        private IDireccionBLL _direccionDAL;
        public DireccionController()
        {
            _direccionDAL = new DireccionBLLImpl();
        }
        #endregion

        #region Conversiones
        DireccionModel Convertir(Direccion entity)
        {
            return new DireccionModel
            {
                IdDireccion = entity.IdDireccion,
                NombreDireccion = entity.NombreDireccion,
                IdDistrito = entity.IdDistrito
            };
        }

        Direccion Convertir(DireccionModel entity)
        {
            return new Direccion
            {
                IdDireccion = entity.IdDireccion,
                NombreDireccion = entity.NombreDireccion,
                IdDistrito = entity.IdDistrito
            };
        }
        #endregion

        #region Create
        // POST api/<DireccionController>
        [HttpPost]
        public JsonResult Post([FromBody] DireccionModel entity)
        {
            try
            {
                Direccion objeto = Convertir(entity);
                _direccionDAL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<DireccionController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Direccion> entity;
            entity = _direccionDAL.GetAll();

            List<DireccionModel> result = new List<DireccionModel>();

            foreach (Direccion item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }

        [Route("GetByNameDireccion")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Direccion> entity;
            entity = _direccionDAL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<DireccionController>/5
        [HttpGet("{id}", Name = "GetDireccion")]
        public JsonResult Get(int id)
        {
            Direccion entity;
            entity = _direccionDAL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<DireccionController>/5
        [HttpPut]
        public JsonResult Put([FromBody] DireccionModel entity)
        {
            try
            {
                _direccionDAL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<DireccionController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Direccion entity = new Direccion { IdDireccion = id };

                _direccionDAL.Remove(entity);
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
