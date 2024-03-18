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
    public class AvisoController : ControllerBase
    {
        #region Constructor
        private IAvisoBLL _avisoBLL;
        public AvisoController()
        {
            _avisoBLL = new AvisoBLLImpl();
        }
        #endregion

        #region Conversiones
        AvisoModel Convertir(Aviso entity)
        {
            return new AvisoModel
            {
                IdAviso = entity.IdAviso,
                IdUsuario = entity.IdUsuario,
                Fecha = entity.Fecha,
                Comentario = entity.Comentario
            };
        }

        Aviso Convertir(AvisoModel entity)
        {
            return new Aviso
            {
                IdAviso = entity.IdAviso,
                IdUsuario = entity.IdUsuario,
                Fecha = entity.Fecha,
                Comentario = entity.Comentario
            };
        }
        #endregion

        #region Create
        // POST api/<AvisoController>
        [HttpPost]
        public JsonResult Post([FromBody] AvisoModel entity)
        {
            try
            {
                Aviso aviso = Convertir(entity);
                _avisoBLL.Add(aviso);
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
                IEnumerable<Aviso> entity;
                entity = _avisoBLL.GetAll();

                List<AvisoModel> result = new List<AvisoModel>();

                foreach (Aviso item in entity)
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


        [Route("GetByNameAviso")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            try
            {
                return new JsonResult(_avisoBLL.GetByName(name));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<AvisoController>/5
        [HttpGet("{id}", Name = "GetAviso")]
        public JsonResult Get(int id)
        {
            try
            {
                Aviso entity;
                entity = _avisoBLL.Get(id);

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
        public JsonResult Put([FromBody] AvisoModel entity)
        {
            try
            {
                _avisoBLL.Update(Convertir(entity));
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
                Aviso entity = new Aviso { IdAviso = id };

                _avisoBLL.Remove(entity);
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
