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
    public class DistritoController : ControllerBase
    {
        #region Constructor
        private IDistritoBLL _distritoBLL;


        public DistritoController()
        {
            _distritoBLL = new DistritoBLLImpl();
        }
        #endregion

        #region Conversiones
        DistritoModel Convertir(Distrito entity)
        {
            return new DistritoModel
            {
                IdDistrito = entity.IdDistrito,
                NombreDistrito = entity.NombreDistrito,
                IdCanton = entity.IdCanton
            };
        }

        Distrito Convertir(DistritoModel entity)
        {
            return new Distrito
            {
                IdDistrito = entity.IdDistrito,
                NombreDistrito = entity.NombreDistrito,
                IdCanton = entity.IdCanton
            };
        }
        #endregion

        #region Create
        // POST api/<DistritoController>
        [HttpPost]
        public JsonResult Post([FromBody] DistritoModel entity)
        {
            try
            {

                Distrito objeto = Convertir(entity);
                _distritoBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<DistritoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Distrito> entity;
            entity = _distritoBLL.GetAll();

            List<DistritoModel> result = new List<DistritoModel>();

            foreach (Distrito item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameDistrito")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Distrito> entity;
            entity = _distritoBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<DistritoController>/5
        [HttpGet("{id}", Name = "GetDistrito")]
        public JsonResult Get(int id)
        {
            Distrito entity;
            entity = _distritoBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<DistritoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] DistritoModel entity)
        {
            try
            {
                _distritoBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Distrito entity = new Distrito { IdDistrito = id };

                _distritoBLL.Remove(entity);
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
