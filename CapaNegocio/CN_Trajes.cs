using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Trajes:datosEmpresa
    {
        private ConsultaTrajes trajes_cn = new ConsultaTrajes();

        public DataTable mostrartrajes()
        {
            DataTable tabla = new DataTable();
            tabla = trajes_cn.mostrar();
            return tabla;

        }

        
        

        

    }
}
