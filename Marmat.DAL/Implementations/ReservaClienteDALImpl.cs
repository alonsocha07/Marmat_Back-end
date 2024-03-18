using BackEnd.Models;
using Common.Cache;
using Marmat.DAL.Contracts;
using Marmat.DAL.Implementations;
using Marmat.DML;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace Marmat.DAL.Implementations
{
    public class ReservaClienteDALImpl : IReservaClienteDAL
    {
        #region Constructor
        Condominios_MarmatContext context;

        public ReservaClienteDALImpl()
        {
            context = new Condominios_MarmatContext();
        }

        public ReservaClienteDALImpl(Condominios_MarmatContext condominios_MarmatContext)
        {
            this.context = condominios_MarmatContext;
        }

        public bool Add(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ReservaCliente> entities)
        {
            throw new NotImplementedException();
        }

        public bool DateCheck(DateTime fecha, int areaComun)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservaCliente> Find(Expression<Func<ReservaCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ReservaCliente Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservaCliente> GetAll()
        {
            try
            {
                IEnumerable<ReservaCliente> ReservaCLienteList;

                using (context = new Condominios_MarmatContext())
                {

                    ReservaCLienteList = (from Us in context.Usuarios
                                          join dep in context.Departamentos on Us.IdUsuario equals dep.IdUsuario
                                          join con in context.Condominios on dep.IdCondominio equals con.IdCondominio into table1
                                          from con in table1.DefaultIfEmpty()
                                          join Ar in context.Areacomuns on con.IdAreacomun equals Ar.IdAreacomun into table2
                                          from Ar in table2.DefaultIfEmpty()
                                          join Re in context.Reservas on Ar.IdAreacomun equals Re.IdAreacomun into table3
                                          from Re in table3.DefaultIfEmpty()
                                          select new ReservaCliente { IdReserva = Re.FechaReserva, IdAreaComun = Ar.NombreAreacomun, IdCondominio = con.NombreCondominio, IdUsuario = Us.NombreUsuario }).ToList();
                }
                return ReservaCLienteList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Reserva> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string usuario, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ReservaCliente> entities)
        {
            throw new NotImplementedException();
        }

        public ReservaCliente SingleOrDefault(Expression<Func<ReservaCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReservaCliente entity)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
