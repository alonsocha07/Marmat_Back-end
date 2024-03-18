using Common;
using Common.Cache;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace Marmat.DAL.Implementations
{
    public class UsuarioDALImpl : IUsuarioDAL
    {
        #region Constructor
        Condominios_MarmatContext context;
        UserDML _usuarioLoging;
        public UsuarioDALImpl()
        {
            context = new Condominios_MarmatContext();
            _usuarioLoging = new UserDML();
        }

        public UsuarioDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }
        #endregion

        #region Create
        public bool Add(Usuario usuario)
        {
            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    unidad.genericDAL.Add(usuario);
                    RegistrarBitacora("Usuario creado: \n\n"
                    + "Nombre usuario: " + usuario.NombreUsuario + ", \n"
                    + "Nombre: " + usuario.Nombre + ", \n"
                    + "Primer apellido: " + usuario.PrimerApellido + ", \n"
                    + "Segundo apellido: " + usuario.SegundoApellido + ", \n"
                    + "Numero tel: " + usuario.NumeroTel + ", \n"
                    + "Id rol: " + usuario.IdRol);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read
        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int idUsuario)
        {
            try
            {
                Usuario usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.Get(idUsuario);
                }
                return usuario;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> Get()
        {
            try
            {
                IEnumerable<Usuario> usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.GetAll();
                }
                return usuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                IEnumerable<Usuario> usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.GetAll();
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        List<Usuario> IUsuarioDAL.GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetByName(string Name)
        {
            try
            {
                List<Usuario> lista;

                using (context = new Condominios_MarmatContext())
                {
                    lista = (from x in context.Usuarios
                             where x.NombreUsuario.Contains(Name)
                             select x).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public bool Update(Usuario usuario)
        {
            Usuario anterior;
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Usuario> unidadBefore = new UnidadDeTrabajo<Usuario>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(usuario.IdUsuario);
                }
                context = new Condominios_MarmatContext();

                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    unidad.genericDAL.Update(usuario);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla: Usuario modificado, los datos anteriores son: \n\n"

                        + "Nombre usuario: " + anterior.NombreUsuario + ", \n"
                        + "Nombre: " + anterior.Nombre + ", \n"
                        + "Primer apellido: " + anterior.PrimerApellido + ", \n"
                        + "Segundo apellido: " + anterior.SegundoApellido + ", \n"
                        + "Numero tel: " + anterior.NumeroTel + ", \n"
                        + "Id rol: " + anterior.IdRol + ", \n"

                        + ", fueron cambiados por: \n\n"

                        + "Nombre usuario: " + usuario.NombreUsuario + ", \n"
                        + "Nombre: " + usuario.Nombre + ", \n"
                        + "Primer apellido: " + usuario.PrimerApellido + ", \n"
                        + "Segundo apellido: " + usuario.SegundoApellido + ", \n"
                        + "Numero tel: " + usuario.NumeroTel + ", \n"
                        + "Id rol: " + usuario.IdRol);


                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
        #endregion

        #region Delete
        public bool Remove(Usuario usuario)
        {
            Usuario anterior;
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Usuario> unidadBefore = new UnidadDeTrabajo<Usuario>(context))
                {
                    anterior = unidadBefore.genericDAL.Get(usuario.IdUsuario);
                }
                context = new Condominios_MarmatContext();
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    unidad.genericDAL.Remove(usuario);
                    result = unidad.Complete();
                    RegistrarBitacora("Tabla Usuario, datos borrados: \n\n"

                        + "Nombre usuario: " + anterior.NombreUsuario + ", \n"
                        + "Nombre: " + anterior.Nombre + ", \n"
                        + "Primer apellido: " + anterior.PrimerApellido + ", \n"
                        + "Segundo apellido: " + anterior.SegundoApellido + ", \n"
                        + "Numero tel: " + anterior.NumeroTel + ", \n"
                        + "Id rol: " + anterior.IdRol);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AddBinnacle
        public bool RegistrarBitacora(string detalleBitacora)
        {
            using (var conexion = new Condominios_MarmatContext())
            {
                try
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.IdBitacora = 0;
                    bitacora.Descripcion = detalleBitacora;
                    bitacora.Fecha = DateTime.Now;
                    bitacora.IdUsuario = 1;

                    conexion.Bitacoras.Add(bitacora);
                    conexion.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    conexion.Dispose();
                    throw ex;
                }
            }
        }
        #endregion

        #region Login
        public bool LoginUser(string usuario, string pass)
        {
            //encripta pass
            pass = Encrypt.GetSHA256(pass);
            using (var conexion = _usuarioLoging.GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "select *from Usuario where Nombre_Usuario=@usuario and Pass=@pass ";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserLoginCache.IdUsuario = dr.GetInt32(0);
                            UserLoginCache.NombreUsuario = dr.GetString(1);
                            UserLoginCache.Correo = dr.GetString(2);
                            UserLoginCache.Pass = dr.GetString(3);
                            UserLoginCache.Nombre = dr.GetString(4);
                            UserLoginCache.PrimerApellido = dr.GetString(5);
                            UserLoginCache.SegundoApellido = dr.GetString(6);
                            UserLoginCache.NumeroTel = dr.GetInt32(7);
                            UserLoginCache.IdRol = dr.GetInt32(8);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool DateCheck(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public bool DateCheck(DateTime fecha, int areaComun)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
