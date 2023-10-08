using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrosBBDD_CRUD_C_.Dtos;
using LibrosBBDD_CRUD_C_.Servicios;
using LibrosBBDD_CRUD_C_.Util;
using Npgsql;

namespace LibrosBBDD_CRUD_C_
{
    /// <summary>
    /// Clase principal que actúa como controlador de la aplicación.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instancias
            int opcion;
            ProgramInterfaz programInterfaz = new ProgramImplementacion();
            ConexionInterfaz conexionInterfaz = new ConexionImplementacion();
            ConsultasInterfaz crudInterfaz = new ConsultasImplementacion();
            Herramientas hr = new Herramientas();
            NpgsqlConnection conexion = null;
            try
            {
                do
                {   
                    conexion = conexionInterfaz.Conectar();//Abro la conexion cada vez que entro al menú
                    opcion = programInterfaz.Menu();//Muestro y pido la opción
                    switch (opcion)
                    {
                        case 1:
                            if (conexion != null)
                                crudInterfaz.MostrarLibros(conexion);
                            break;
                        case 2:
                            if (conexion != null)
                                crudInterfaz.CrearLibros(conexion);
                            break;
                        case 3:
                            if (conexion != null)
                                crudInterfaz.ActualizarLibros(conexion);
                            break;
                        case 4:
                            if (conexion != null)
                                crudInterfaz.BorrarLibros(conexion);
                            break;
                    }
                } while (opcion != 0);//Si la opcion=0 saldra del menú y de la aplicación.
                Console.WriteLine("[INFO-Program-Main()]-Ha salido de la aplicación");
                conexion.Close();//Cierro la conexión al salir.
                hr.Pausa();

            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR-Program-Main()]-Ha ocurrido al ejecutar la aplicación");
                conexion.Close();
            }
        }
    }
}
