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
    public class BoletinController : ControllerBase
    {
        #region Constructor
        private IBoletinBLL _boletinBLL;
        public BoletinController()
        {
            _boletinBLL = new BoletinBLLImpl();
        }
        #endregion

        #region Conversiones
        BoletinModel Convertir(Boletin entity)
        {
            return new BoletinModel
            {
                IdBoletin = entity.IdBoletin,
                FechaInicio = entity.FechaInicio,
                FechaFinal = entity.FechaFinal,
                Comentario = entity.Comentario
            };
        }

        Boletin Convertir(BoletinModel entity)
        {
            return new Boletin
            {
                IdBoletin = entity.IdBoletin,
                FechaInicio = entity.FechaInicio,
                FechaFinal = entity.FechaFinal,
                Comentario = entity.Comentario
            };
        }
        #endregion

        #region Create
        // POST api/<BoletinController>
        [HttpPost]
        public JsonResult Post([FromBody] BoletinModel entity)
        {
            try
            {
                Boletin boletin = Convertir(entity);
                _boletinBLL.Add(boletin);
                return new JsonResult(Convertir(boletin));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<BoletinController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Boletin> entity;
                entity = _boletinBLL.GetAll();

                List<BoletinModel> result = new List<BoletinModel>();

                foreach (Boletin item in entity)
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


        [Route("GetByNameBoletin")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            try
            {
                return new JsonResult(_boletinBLL.GetByName(name));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<BoletinController>/5
        [HttpGet("{id}", Name = "GetBoletin")]
        public JsonResult Get(int id)
        {
            try
            {
                Boletin entity;
                entity = _boletinBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<BoletinController>/5
        [HttpPut]
        public JsonResult Put([FromBody] BoletinModel entity)
        {
            try
            {
                _boletinBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<BoletinController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Boletin entity = new Boletin { IdBoletin = id };

                _boletinBLL.Remove(entity);
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
