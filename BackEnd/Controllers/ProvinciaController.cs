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
    public class ProvinciaController : ControllerBase
    {
        #region Constructor
        private IProvinciumBLL _provinciaBLL;


        public ProvinciaController()
        {
            _provinciaBLL = new ProvinciumBLLImpl();
        }
        #endregion

        #region Conversiones
        ProvinciaModel Convertir(Provincium entity)
        {
            return new ProvinciaModel
            {
                IdProvincia = entity.IdProvincia,
                NombreProvincia = entity.NombreProvincia
            };
        }

        Provincium Convertir(ProvinciaModel entity)
        {
            return new Provincium
            {
                IdProvincia = entity.IdProvincia,
                NombreProvincia = entity.NombreProvincia
            };
        }
        #endregion

        #region Create
        // POST api/<ProvinciaController>
        [HttpPost]
        public JsonResult Post([FromBody] ProvinciaModel entity)
        {
            try
            {

                Provincium objeto = Convertir(entity);
                _provinciaBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<ProvinciaController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Provincium> entity;
            entity = _provinciaBLL.GetAll();

            List<ProvinciaModel> result = new List<ProvinciaModel>();

            foreach (Provincium item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameProvincia")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Provincium> entity;
            entity = _provinciaBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<ProvinciaController>/5
        [HttpGet("{id}", Name = "GetProvincia")]
        public JsonResult Get(int id)
        {
            Provincium entity;
            entity = _provinciaBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<ProvinciaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ProvinciaModel entity)
        {
            try
            {
                _provinciaBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<ProvinciaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Provincium entity = new Provincium { IdProvincia = id };

                _provinciaBLL.Remove(entity);
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
