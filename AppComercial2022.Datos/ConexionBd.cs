using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppComercial2022.Datos
{
    public class ConexionBd
    {
        private string cadenaConexion;
        private SqlConnection cn;

        public ConexionBd()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public SqlConnection GetConexion()
        {
            cn=new SqlConnection(cadenaConexion);
            cn.Open();
            return cn;
        }

        public void CerrarConexion()
        {
            if (cn.State==ConnectionState.Open)
            {
                cn.Close();
            }
        }

    }
}
