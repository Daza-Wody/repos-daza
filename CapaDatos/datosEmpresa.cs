using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;
using CapaDatos.cacheSotfware;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class datosEmpresa:CD_Conexion
    {
        
        private string contraseña;
        private string usuario;
        private string nombre;
        private int celular;
        private string correo;

        public string Contraseña { get { return contraseña; } set { contraseña = value; } }
        public string Usuario  { get { return usuario; } set { usuario = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Celular { get { return celular; } set { celular = value; } }
        public string Correo { get { return correo; } set { correo = value; } }

        public datosEmpresa()
        {
            contraseña = Contraseña;
            usuario = Usuario;
            nombre = Nombre;
            celular = Celular;
            correo = Correo;
        }

        public bool login(string usuario, string contraseña)
        {
            using (var conexion_e = obtenerconexion())
            {
                conexion_e.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion_e;
                    comando.CommandText = @"select * from empresa where usuario_empresa = @usuario 
                    and CONVERT(nvarchar(MAX), DECRYPTBYPASSPHRASE('password',contrase_empresa))= @contraseña";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            Cachesoftware.id_empresa = lector.GetInt32(0);
                        
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
    }
}
