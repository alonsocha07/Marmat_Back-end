using BackEnd.Models;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DAL.Interface;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        #region Constructor
        private ITickectBLL _ticketBLL;


        public TicketController()
        {
            _ticketBLL = new TicketBLLImpl();
        }
        #endregion

        #region Conversiones
        TicketModel Convertir(Ticket entity)
        {
            return new TicketModel
            {
                IdTicket = entity.IdTicket,
                Descripcion = entity.Descripcion,
                IdEstado = entity.IdEstado,
                IdUsuario = entity.IdUsuario,
                IdDepartamento = entity.IdDepartamento
            };
        }
        Ticket Convertir(TicketModel entity)
        {
            return new Ticket
            {
                IdTicket = entity.IdTicket,
                Descripcion = entity.Descripcion,
                IdEstado = entity.IdEstado,
                IdUsuario = entity.IdUsuario,
                IdDepartamento = entity.IdDepartamento
            };
        }
        #endregion

        #region Create
        // POST api/<TicketController>
        [HttpPost]
        public JsonResult Post([FromBody] TicketModel entity)
        {
            try
            {
                Ticket objeto = Convertir(entity);
                _ticketBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<TicketController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Ticket> entity;
            entity = _ticketBLL.GetAll();

            List<TicketModel> result = new List<TicketModel>();

            foreach (Ticket item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameTicket")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Ticket> entity;
            entity = _ticketBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}", Name = "GetTicket")]
        public JsonResult Get(int id)
        {
            Ticket entity;
            entity = _ticketBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<RolController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TicketModel entity)
        {
            try
            {
                _ticketBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Ticket entity = new Ticket { IdTicket = id };

                _ticketBLL.Remove(entity);
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
