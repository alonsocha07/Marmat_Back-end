using BackEnd.Models;
using Marmat.BLL.Implementations;
using Marmat.DML;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CatalogoController : Controller
    {
        #region Constructor
        private CorreoBLLImpl _correoBLL;
        private CondominioBLLImpl _condominioBLL;
        public CatalogoController()
        {
            _correoBLL = new CorreoBLLImpl();
            _condominioBLL = new CondominioBLLImpl();
            
        }
        #endregion

        #region Conversiones
        CatalogoModel Convertir(Catalogo entity)
        {
            return new CatalogoModel
            {
                nombre = entity.nombre,
                apellidos = entity.apellidos,
                numero = entity.numero,
                correo = entity.correo,
                mensaje = entity.mensaje

            };
        }

        Catalogo Convertir(CatalogoModel entity)
        {
            return new Catalogo
            {
                nombre = entity.nombre,
                apellidos = entity.apellidos,
                numero = entity.numero,
                correo = entity.correo,
                mensaje = entity.mensaje,
                NombreCondominio =entity.NombreCondominio
            };
        }

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
            };
        }

        CatalogoModel ConvertirCondominioCatalogo(CondominioModel entity)
        {
            return new CatalogoModel
            {
                IdCondominio = entity.IdCondominio,
                NombreCondominio = entity.NombreCondominio,
                Vacantes = entity.Vacantes,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdDireccion = entity.IdDireccion,


            };
        }

        CatalogoModel ConvertirCondominioCatalogoYDireccion(CondominioModel entity, string direccion)
        {
            return new CatalogoModel
            {
                IdCondominio = entity.IdCondominio,
                NombreCondominio = entity.NombreCondominio,
                Vacantes = entity.Vacantes,
                Descripcion = entity.Descripcion,
                Imagen = entity.Imagen,
                IdDireccion = entity.IdDireccion,
                Direccion = direccion

            };
        }

        AvisoVisitantesModel Convertir(CorreoVisitas entity)
        {
            return new AvisoVisitantesModel
            {
                Fecha = entity.Fecha,
                Comentario = entity.Comentario

            };
        }

        CorreoVisitas Convertir(AvisoVisitantesModel entity)
        {
            return new CorreoVisitas
            {
                Fecha = entity.Fecha,
                Comentario = entity.Comentario
            };
        }
        #endregion

        #region Correo
        [HttpPost]
        public bool Post([FromBody] CatalogoModel catalogoCorreo)
        {
            try
            {
                try
                {
                    // Correo objeto = Convertir(correo);
                    return _correoBLL.MandarCorreo(Convertir(catalogoCorreo));
                }
                catch (Exception ex)
                {
                    throw ex; ;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("Visitas")]
        [HttpPost]
        public bool Post([FromBody] AvisoVisitantesModel visitasCorreo)
        {
            try
            {
                try
                {
                    // Correo objeto = Convertir(correo);
                    return _correoBLL.MandarCorreoVisitas(Convertir(visitasCorreo));
                }
                catch (Exception ex)
                {
                    throw ex; ;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                IEnumerable<Condominio> entity;
                entity = _condominioBLL.GetAll();
                

                List<CatalogoModel> result = new List<CatalogoModel>();

                foreach (Condominio item in entity)
                {
                    string direccion = _condominioBLL.GetDireccion(item.IdDireccion);
                    //Este metodo usa un Convertir especial para meter la direccion coomo String en el modelo
                    result.Add(ConvertirCondominioCatalogoYDireccion(Convertir(item), direccion));
                    
                }
                return new JsonResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}", Name = "GetCatalogo")]
        public JsonResult Get(int id)
        {
            try
            {
                Condominio entity;
                entity = _condominioBLL.Get(id);

                return new JsonResult(ConvertirCondominioCatalogo(Convertir(entity)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("GetByNameCatalogo")]
        [HttpGet]
        public ActionResult GetByName(string name)
        {
            try
            {
                IEnumerable<Condominio> entity;
                entity = _condominioBLL.GetByName(name);

                List<CatalogoModel> result = new List<CatalogoModel>();

                foreach (Condominio item in entity)
                {
                    string direccion = _condominioBLL.GetDireccion(item.IdDireccion);

                    result.Add(ConvertirCondominioCatalogoYDireccion(Convertir(item), direccion));
                }
                return new JsonResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("GetByProvinciaCatalogo")]
        [HttpGet]
        public ActionResult GetByProvincia(string provinciaid)
        {
            try
            {
                IEnumerable<Condominio> entity;
                entity = _condominioBLL.GetByProvincia(provinciaid);

                List<CatalogoModel> result = new List<CatalogoModel>();

                foreach (Condominio item in entity)
                {
                    string direccion = _condominioBLL.GetDireccion(item.IdDireccion);
                    result.Add(ConvertirCondominioCatalogoYDireccion(Convertir(item), direccion));
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
