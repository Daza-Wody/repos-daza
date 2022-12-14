using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datoscliente:CD_Conexion

    {
        private string nombre;
        private int celular;
        private string dni;
        private string descripcion;


        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Celular { get { return celular; } set { celular = value; } }
        public string DNI { get { return dni; } set { dni = value; } }
        public string Descripcion { get { return descripcion; } set {  descripcion = value; } }


        public datoscliente()
        {
            nombre = Nombre;
            celular = Celular;
            dni = DNI;
            descripcion = Descripcion;
        }


    }
}
