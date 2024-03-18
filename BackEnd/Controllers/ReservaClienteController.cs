using BackEnd.Models;
using Common.Cache;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaClienteController : ControllerBase
    {
        #region Constructor
        private IReservaClienteBLL _reservaClienteBLL;
        public ReservaClienteController()
        {
            _reservaClienteBLL = new ReservaClienteBLLImpl();
        }
        #endregion

        #region Conversiones
        ReservaClienteModel Convertir(ReservaCliente entity)
        {
            return new ReservaClienteModel
            {
                IdReserva = entity.IdReserva,
                IdCondominio = entity.IdCondominio,
                IdAreaComun = entity.IdAreaComun,
                IdUsuario = entity.IdUsuario
            };
        }

        ReservaCliente Convertir(ReservaClienteModel entity)
        {
            return new ReservaCliente
            {
                IdReserva = entity.IdReserva,
                IdCondominio = entity.IdCondominio,
                IdAreaComun = entity.IdAreaComun,
                IdUsuario = entity.IdUsuario
            };
        }
        #endregion

        #region Read
        // GET: api/<AvisoController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<ReservaCliente> entity;
                entity = _reservaClienteBLL.GetAll();

                List<ReservaClienteModel> result = new List<ReservaClienteModel>();

                foreach (ReservaCliente item in entity)
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
        #endregion



    }
}
