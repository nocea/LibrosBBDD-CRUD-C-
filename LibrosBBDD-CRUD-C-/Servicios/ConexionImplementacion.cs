using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    /// <summary>
    /// Implementación de la interfaz de conexión para postgresql
    /// </summary>
    internal class ConexionImplementacion:ConexionInterfaz
    {
        public NpgsqlConnection Conectar()
        {
            string stringCon = ConfigurationManager.ConnectionStrings["datosConexion"].ConnectionString;//obtengo los datos
            NpgsqlConnection conexion = null;
            if (!string.IsNullOrWhiteSpace(stringCon))//Gi no esta vacío
            {
                try
                {
                    conexion = new NpgsqlConnection(stringCon);//Genero la conexion con su string.
                    conexion.Open();//La abro
                }
                catch (NpgsqlException e)
                {
                    Console.WriteLine("[ERROR-ConexionImplementacion-Conectar()]-No se ha podido conectar con la base de datos");
                    conexion = null;//Si da error la declaro null para poder comprobarla después.
                    return conexion;
                }
            }
            Console.WriteLine("[INFO-ConexionImplementacion-Conectar()]-Se ha conectado con la base de datos");
            return conexion;
        }
    }
}
