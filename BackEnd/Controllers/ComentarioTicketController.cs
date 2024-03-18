using BackEnd.Models;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioTicketController : ControllerBase
    {
        #region Constructor
        private ComentarioTicketBLLImpl _comentarioTicketBLL;
        /// <summary>
        /// Controlador del Controller Condominios
        /// </summary>
        public ComentarioTicketController()
        {
            _comentarioTicketBLL = new ComentarioTicketBLLImpl();
        }
        #endregion

        #region Conversiones
        ComentarioTicketModel Convertir(ComentarioTicket entity)
        {
            return new ComentarioTicketModel
            {
                IdComentarioTicket = entity.IdComentarioTicket,
                Fecha = entity.Fecha,
                Comentario = entity.Comentario,
                IdTicket = entity.IdTicket
            };
        }

        ComentarioTicket Convertir(ComentarioTicketModel entity)
        {
            return new ComentarioTicket
            {
                IdComentarioTicket = entity.IdComentarioTicket,
                Fecha = entity.Fecha,
                Comentario = entity.Comentario,
                IdTicket = entity.IdTicket
            };
        }
        #endregion

        #region Create
        // POST api/<ComentarioTicketController>
        [HttpPost]
        public JsonResult Post([FromBody] ComentarioTicketModel comentarioTicket)
        {
            try
            {
                ComentarioTicket objeto = Convertir(comentarioTicket);
                _comentarioTicketBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Obtiene la lista de todos los condominios activos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                IEnumerable<ComentarioTicket> entity;
                entity = _comentarioTicketBLL.GetAll();

                List<ComentarioTicketModel> result = new List<ComentarioTicketModel>();

                foreach (ComentarioTicket item in entity)
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
        /// <summary>
        /// Obtiene los condominios por medio de su nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("GetByNameComentarioTicket")]
        [HttpGet]
        public ActionResult GetByName(string name)
        {
            try
            {
                IEnumerable<ComentarioTicket> entity;
                entity = _comentarioTicketBLL.GetByName(name);

                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ComentarioTicketController>/5
        [HttpGet("{id}", Name = "GetComentarioTicket")]
        public JsonResult Get(int id)
        {
            try
            {
                ComentarioTicket entity;
                entity = _comentarioTicketBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<ComentarioTicketController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ComentarioTicketModel condominio)
        {
            try
            {
                _comentarioTicketBLL.Update(Convertir(condominio));
                return new JsonResult(condominio);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<ComentarioTicketController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                ComentarioTicket entity = new ComentarioTicket { IdComentarioTicket = id };

                _comentarioTicketBLL.Remove(entity);
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
