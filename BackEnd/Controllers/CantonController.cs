using BackEnd.Models;
using Marmat.BLL.Implementations;
using Marmat.DAL.Contracts;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantonController : ControllerBase
    {
        #region Constructor
        private CantonBLLImpl _cantonBLL;
        public CantonController()
        {
            _cantonBLL = new CantonBLLImpl();
        }
        #endregion

        #region Conversiones
        CantonModel Convertir(Canton entity)
        {
            return new CantonModel
            {
                IdCanton = entity.IdCanton,
                NombreCanton = entity.NombreCanton,
                IdProvincia = entity.IdProvincia
            };
        }

        Canton Convertir(CantonModel entity)
        {
            return new Canton
            {
                IdCanton = entity.IdCanton,
                NombreCanton = entity.NombreCanton,
                IdProvincia = entity.IdProvincia
            };
        }
        #endregion

        #region Create
        // POST api/<CantonController>
        [HttpPost]
        public JsonResult Post([FromBody] CantonModel canton)
        {
            try
            {
                try
                {
                    Canton objeto = Convertir(canton);
                    _cantonBLL.Add(objeto);
                    return new JsonResult(Convertir(objeto));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<CantonController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Canton> entity;
            entity = _cantonBLL.GetAll();

            List<CantonModel> result = new List<CantonModel>();

            foreach (Canton item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameCanton")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            try
            {
                IEnumerable<Canton> entity;
                entity = _cantonBLL.GetByName(name);

                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<CantonController>/5
        [HttpGet("{id}", Name = "GetCanton")]
        public JsonResult Get(int id)
        {
            try
            {
                Canton entity;
                entity = _cantonBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<CantonController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CantonModel canton)
        {
            try
            {
                _cantonBLL.Update(Convertir(canton));
                return new JsonResult(canton);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<CantonController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Canton entity = new Canton { IdCanton = id };

                _cantonBLL.Remove(entity);
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
