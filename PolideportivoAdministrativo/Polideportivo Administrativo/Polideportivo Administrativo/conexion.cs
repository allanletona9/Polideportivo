﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Polideportivo_Administrativo
{
   class conexion
    {
        public  OdbcConnection conectar()
        {
            OdbcConnection conexion = new OdbcConnection("Dsn=polideportivo");
            conexion.Open();
            return conexion;

        }

        public  OdbcConnection cerrarConexion()
        {
            OdbcConnection conexion = new OdbcConnection("Dsn=polideportivo");
            conexion.Close();
            return conexion;
        }
    }
}
