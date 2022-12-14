using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
     public class ConsultaTrajes:CD_Conexion
    {

        SqlConnection gozu;
        SqlDataReader? leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable mostrar()
        {
            gozu = obtenerconexion();
            gozu.Open();
            comando.Connection = gozu;
            comando.CommandText = "Select * from Trajes";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            return tabla;
        }
            
        

    }
}
