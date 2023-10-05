using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    internal class ConexionImplementacion:ConexionInterfaz
    {
        public NpgsqlConnection Conectar()
        {
            string stringCon = ConfigurationManager.ConnectionStrings["datosConexion"].ConnectionString;
            NpgsqlConnection conexion = null;
            if (!string.IsNullOrWhiteSpace(stringCon))
            {
                try
                {
                    conexion = new NpgsqlConnection(stringCon);
                    conexion.Open();
                }
                catch (NpgsqlException e)
                {
                    Console.WriteLine("[ERROR-ConexionImplementacion-Conectar()]-No se ha podido conectar con la base de datos");
                    conexion = null;
                    return conexion;
                }
            }
            Console.WriteLine("[INFO-ConexionImplementacion-Conectar()]-Se ha conectado con la base de datos");
            return conexion;
        }
    }
}
