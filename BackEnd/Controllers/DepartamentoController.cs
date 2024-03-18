using BackEnd.Models;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        #region Constructor
        private DepartamentoBLLImpl _departamentoBLL;
        public DepartamentoController()
        {
            _departamentoBLL = new DepartamentoBLLImpl();
        }
        #endregion

        #region Conversiones
        DepartamentoModel Convertir(Departamento entity)
        {
            return new DepartamentoModel
            {
                IdDepartamento = entity.IdDepartamento,
                CantidadCuartos = entity.CantidadCuartos,
                CantidadBanios = entity.CantidadBanios,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdUsuario = entity.IdUsuario,
                IdCondominio = entity.IdCondominio
            };
        }

        Departamento Convertir(DepartamentoModel entity)
        {
            return new Departamento
            {
                IdDepartamento = entity.IdDepartamento,
                CantidadCuartos = entity.CantidadCuartos,
                CantidadBanios = entity.CantidadBanios,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdUsuario = entity.IdUsuario,
                IdCondominio = entity.IdCondominio
            };
        }
        #endregion

        #region Create
        // POST api/<DepartamentoController>
        [HttpPost]
        public JsonResult Post([FromBody] DepartamentoModel entity)
        {
            try
            {
                Departamento objeto = Convertir(entity);
                _departamentoBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: api/<DepartamentoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Departamento> entity;
            entity = _departamentoBLL.GetAll();

            List<DepartamentoModel> result = new List<DepartamentoModel>();

            foreach (Departamento item in entity)
            {
                result.Add(Convertir(item));
            }

            return new JsonResult(result);
        }


        [Route("GetByNameDepartamento")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Departamento> entity;
            entity = _departamentoBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        [Route("GetByIdCondominio")]
        [HttpGet]
        public JsonResult GetByIdCondominio(int idCondominio)
        {
            
            List<DepartamentoModel> result = new List<DepartamentoModel>();
            IEnumerable<Departamento> entity;

            entity = _departamentoBLL.GetByIdCondominio(idCondominio);

            foreach (Departamento item in entity)
            {
                result.Add(Convertir(item));
            }
           

            return new JsonResult(result);
        }


        // GET api/<DepartamentoController>/5
        [HttpGet("{id}", Name = "GetDepartamento")]
        public JsonResult Get(int id)
        {
            Departamento entity;
            entity = _departamentoBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<DepartamentoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] DepartamentoModel entity)
        {
            try
            {
                _departamentoBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Departamento entity = new Departamento { IdDepartamento = id };

                _departamentoBLL.Remove(entity);
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
