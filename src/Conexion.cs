using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Escuela.src
{
    class Conexion
    {
        private static Conexion instance = new Conexion();
        private SqlConnection conexion;

        private Conexion()
        {
           // conexion = new SqlConnection(Properties.Settings.Default.conexion);
            conexion = new SqlConnection("Data Source=localhost; Initial Catalog = SistemaEscuela; Integrated Security = True");
            conexion.Open();
        }

        public static Conexion getInstance()
        {
            return instance;
        }

        public SqlConnection getConexion() 
        {
            return conexion;
        }

    }
}
