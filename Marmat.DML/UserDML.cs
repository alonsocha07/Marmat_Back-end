using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Marmat.DML
{
    public class UserDML : Condominios_MarmatContext
    {

        private string conexion;
        public SqlConnection GetConnection()
        {
            conexion = "Server=tcp:servermarmatbd.database.windows.net,1433;Initial Catalog=Condominios_Marmat_BD;Persist Security Info=False;User ID=administrador;Password=marmatASEE22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(conexion);
        }
    }
}
