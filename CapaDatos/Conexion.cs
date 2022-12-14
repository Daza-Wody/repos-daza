using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;


namespace CapaDatos
{   
    
    public  class CD_Conexion
    {
        //private SqlConnection Conex = new SqlConnection("Server =DESKTOP-NGKU4IB; DataBase = bd_corregido_admin ; Integrated Security = true ");
        private readonly string cadenadeconexion;

        public CD_Conexion()
        {
            cadenadeconexion = "Server =DESKTOP-NGKU4IB; DataBase = bd_corregido_admin ; Integrated Security = true ";
        }
        protected SqlConnection obtenerconexion()
        {
            return new SqlConnection(cadenadeconexion);
        }
        //sqlparameter la usamos para especificar parametros en nuestro procedimiento almacenado
        protected List<SqlParameter> parametros; 
        /*metodo para leer los procedimientos almacenados*/
        protected void ExecutNoQuery(string transacSql)
        {
            using (var conexion = obtenerconexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transacSql;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    comando.ExecuteNonQuery();
                    parametros.Clear();
                }
            }
        }
        // metodo para abrir y cerrar la conexion
        
        
        //metodo para leer en lista
        protected DataTable ExecuReader(string transacSql)
        {
            using (var conexion = obtenerconexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = transacSql;
                    comando.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    SqlDataReader lector = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(lector);
                        lector.Dispose();
                        return tabla;
                    }
                }
            }
        }
    }
}
