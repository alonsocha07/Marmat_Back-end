using BackEnd.Models;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DAL.Contracts;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaComunController : ControllerBase
    {
        #region Constructor
        private IAreaComunBLL _areaComunBLL;
        public AreaComunController()
        {
            _areaComunBLL = new AreaComunBLLImpl();
        }
        #endregion

        #region Conversiones
        AreacomunModel Convertir(Areacomun entity)
        {
            return new AreacomunModel
            {
                IdAreacomun = entity.IdAreacomun,
                NombreAreacomun = entity.NombreAreacomun
            };
        }

        Areacomun Convertir(AreacomunModel entity)
        {
            return new Areacomun
            {
                IdAreacomun = entity.IdAreacomun,
                NombreAreacomun = entity.NombreAreacomun
            };
        }
        #endregion

        #region Create
        // POST api/<AvisoController>
        [HttpPost]
        public JsonResult Post([FromBody] AreacomunModel entity)
        {
            try
            {
                Areacomun aviso = Convertir(entity);
                _areaComunBLL.Add(aviso);
                return new JsonResult(Convertir(aviso));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<AvisoController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Areacomun> entity;
                entity = _areaComunBLL.GetAll();

                List<AreacomunModel> result = new List<AreacomunModel>();

                foreach (Areacomun item in entity)
                {
                    result.Add(Convertir(item));
                }
                return new JsonResult(result);

            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("GetByNameAreaComun")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            try
            {
                return new JsonResult(_areaComunBLL.GetByName(name));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<AvisoController>/5
        [HttpGet("{id}", Name = "GetAreaComun")]
        public JsonResult Get(int id)
        {
            try
            {
                Areacomun entity;
                entity = _areaComunBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<AvisoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] AreacomunModel entity)
        {
            try
            {
                _areaComunBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<AvisoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Areacomun entity = new Areacomun { IdAreacomun = id };

                _areaComunBLL.Remove(entity);
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
