using CapaDatos.cacheSotfware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datosEmpleado : CD_Conexion
    {
        private string contraseña;
        private string nombre;
        private string usuario;
        private int celular;
        private int dni;
        private int id_empresa;
        private string direccion_correo;
        public string Contraseña { get { return contraseña; } set { contraseña = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Usuario { get { return usuario; } set { usuario = value; } }
        public int Celular { get { return celular; } set { celular = value; } }

        public int Dni { get { return dni; } set { dni = value; } }

        public int ID_empresa { get { return id_empresa; } set { id_empresa = value; } }

        public string Direccion_correo
        {
            get { return direccion_correo; }
            set { direccion_correo = value; }
        }


        public datosEmpleado()
        {
            contraseña = Contraseña;
            nombre = Nombre;
            usuario = Usuario;
            celular = Celular;
            dni = Dni;
            id_empresa = ID_empresa;
            direccion_correo = Direccion_correo;

        }

        //metodo para ingresar datos




        //meetodo para confirmar el usuario y contraseña para ingresar al sistema
        public bool login(string usuario, string contraseña)
        {
            using (var conexio_emp = obtenerconexion())
            {


                conexio_emp.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexio_emp;
                    comando.CommandText = @"select * from empresa where @usuario_empresa = @usuario and CONVERT(nvarchar(MAX), DECRYPTBYPASSPHRASE('password',contrase_empresa))= @contraseña";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@usuario_empresa", usuario);
                    comando.Parameters.AddWithValue("@contrase_empresa", contraseña);
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
