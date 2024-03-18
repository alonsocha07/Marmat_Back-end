using BackEnd.Models;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        #region Constructor
        private CondominioBLLImpl _condominioBLL;
        /// <summary>
        /// Controlador del Controller Condominios
        /// </summary>
        public CondominioController()
        {
            _condominioBLL = new CondominioBLLImpl();
        }
        #endregion

        #region Conversiones
        CondominioModel Convertir(Condominio entity)
        {
            return new CondominioModel
            {
                IdCondominio = entity.IdCondominio,
                NombreCondominio = entity.NombreCondominio,
                Vacantes = entity.Vacantes,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdDireccion = entity.IdDireccion,
                IdAreacomun=entity.IdAreacomun
            };
        }

        Condominio Convertir(CondominioModel entity)
        {
            return new Condominio
            {
                IdCondominio = entity.IdCondominio,
                NombreCondominio = entity.NombreCondominio,
                Vacantes = entity.Vacantes,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdDireccion = entity.IdDireccion,
                IdAreacomun=entity.IdAreacomun
            };
        }
        #endregion

        #region Create
        // POST api/<CondominioController>
        [HttpPost]
        public JsonResult Post([FromBody] CondominioModel condominio)
        {
            try
            {
                Condominio objeto = Convertir(condominio);
                _condominioBLL.Add(objeto);
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
                IEnumerable<Condominio> entity;
                entity = _condominioBLL.GetAll();

                List<CondominioModel> result = new List<CondominioModel>();

                foreach (Condominio item in entity)
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
        [Route("GetByNameCondominio")]
        [HttpGet]
        public ActionResult GetByName(string name)
        {
            try
            {
                IEnumerable<Condominio> entity;
                entity = _condominioBLL.GetByName(name);

                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<CondominioController>/5
        [HttpGet("{id}", Name = "GetCondominio")]
        public JsonResult Get(int id)
        {
            try
            {
                Condominio entity;
                entity = _condominioBLL.Get(id);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        // PUT api/<CondominioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CondominioModel condominio)
        {
            try
            {
                _condominioBLL.Update(Convertir(condominio));
                return new JsonResult(condominio);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<CondominioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Condominio entity = new Condominio { IdCondominio = id };

                _condominioBLL.Remove(entity);
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
