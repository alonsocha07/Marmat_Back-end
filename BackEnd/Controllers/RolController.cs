using BackEnd.Models;
using Marmat.BLL.Contracts;
using Marmat.BLL.Implementations;
using Marmat.DAL.Interface;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        #region Constructor
        private IRolBLL _rolBLL;


        public RolController()
        {
            _rolBLL = new RolBLLImpl();
        }
        #endregion

        #region Conversiones
        RolModel Convertir(Rol entity)
        {
            return new RolModel
            {
                IdRol = entity.IdRol,
                NombreRol = entity.NombreRol,
            };
        }

        Rol Convertir(RolModel entity)
        {
            return new Rol
            {
                IdRol = entity.IdRol,
                NombreRol = entity.NombreRol,
            };
        }
        #endregion

        #region Create
        // POST api/<RolController>
        [HttpPost]
        public JsonResult Post([FromBody] RolModel entity)
        {
            try
            {
                Rol objeto = Convertir(entity);
                _rolBLL.Add(objeto);
                return new JsonResult(Convertir(objeto));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        
        #region Read
        // GET: api/<RolController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Rol> entity;
            entity = _rolBLL.GetAll();

            List<RolModel> result = new List<RolModel>();

            foreach (Rol item in entity)
            {
                result.Add(Convertir(item));
            }
            return new JsonResult(result);
        }


        [Route("GetByNameRol")]
        [HttpGet]
        public JsonResult GetByName(string Name)
        {
            IEnumerable<Rol> entity;
            entity = _rolBLL.GetByName(Name);

            return new JsonResult(entity);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}", Name = "GetRol")]
        public JsonResult Get(int id)
        {
            Rol entity;
            entity = _rolBLL.Get(id);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Update
        // PUT api/<RolController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RolModel entity)
        {
            try
            {
                _rolBLL.Update(Convertir(entity));
                return new JsonResult(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Rol entity = new Rol { IdRol = id };

                _rolBLL.Remove(entity);
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
