using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrosBBDD_CRUD_C_.Dtos;
using LibrosBBDD_CRUD_C_.Servicios;
using Npgsql;

namespace LibrosBBDD_CRUD_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int opcion;
            ProgramInterfaz programInterfaz = new ProgramImplementacion();
            ConexionInterfaz conexionInterfaz = new ConexionImplementacion();
            ConsultasInterfaz crudInterfaz = new ConsultasImplementacion();
            NpgsqlConnection conexion = null;
            try
            {
                do
                {
                    conexion = conexionInterfaz.Conectar();
                    opcion = programInterfaz.Menu();
                    switch (opcion)
                    {
                        case 1:
                            if (conexion != null)
                                crudInterfaz.MostrarLibros(conexion);
                            break;
                        case 2:
                            crudInterfaz.CrearLibros(conexion);
                            break;
                        case 3:
                            if (conexion != null)
                                crudInterfaz.ActualizarLibros(conexion);
                            break;
                        case 4:
                            crudInterfaz.BorrarLibros(conexion);
                            break;
                    }
                } while (opcion != 0);
                Console.WriteLine("[INFO-Program]-Ha salido de la aplicación");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR-Program]-Ha ocurrido al ejecutar la aplicación");
            }
            conexion.Close();
        }
    }
}
