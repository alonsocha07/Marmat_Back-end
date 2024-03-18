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
    public class BitacoraController : ControllerBase
    {
        #region Constructor
        private IBitacoraBLL _bitacoraBLL;
        public BitacoraController()
        {
            _bitacoraBLL = new BitacoraBLLImpl();
        }
        #endregion

        #region Conversiones
        BitacoraModel Convertir(Bitacora entity)
        {
            return new BitacoraModel
            {
                ID_BITACORA = entity.IdBitacora,
                DESCRIPCION = entity.Descripcion,
                FECHA = entity.Fecha,
                ID_USUARIO = entity.IdUsuario
            };
        }

        Bitacora Convertir(BitacoraModel entity)
        {
            return new Bitacora
            {
                IdBitacora = entity.ID_BITACORA,
                Descripcion = entity.DESCRIPCION,
                Fecha = entity.FECHA,
                IdUsuario = entity.ID_USUARIO
            };
        }
        #endregion

        #region Create
        // POST api/<BitacoraController>
        [HttpPost]
        public JsonResult Post([FromBody] BitacoraModel entity)
        {
            try
            {
                Bitacora bitacora = Convertir(entity);
                _bitacoraBLL.Add(bitacora);
                return new JsonResult(Convertir(bitacora));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<BitacoraController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Bitacora> entity;
                entity = _bitacoraBLL.GetAll();

                List<BitacoraModel> result = new List<BitacoraModel>();

                foreach (Bitacora item in entity)
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


        [Route("GetByNameBitacora")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            try
            {
                return new JsonResult(_bitacoraBLL.GetByName(name));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<BitacoraController>/5
        [HttpGet("{id}", Name = "GetBitacora")]
        public JsonResult Get(int id)
        {
            try
            {
                Bitacora entity;
                entity = _bitacoraBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<BitacoraController>/5
        [HttpPut]
        public JsonResult Put([FromBody] BitacoraModel entity)
        {
            try
            {
                _bitacoraBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<BitacoraController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Bitacora entity = new Bitacora { IdBitacora = id };

                _bitacoraBLL.Remove(entity);
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
