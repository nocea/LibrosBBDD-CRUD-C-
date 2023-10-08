using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    internal class ProgramImplementacion : ProgramInterfaz
    {
        public int Menu()
        {
            int opcion;
            Console.WriteLine("1-->Mostrar Libro/s");
            Console.WriteLine("2-->Crear Libro/s");
            Console.WriteLine("3-->Cambiar Datos de Libros");
            Console.WriteLine("4-->Eliminar Libro");
            Console.WriteLine("0-->Salir de la APP");
            Console.Write("Pulse una de las siguientes opciones:");
            do
            {
                opcion = Convert.ToInt32(Console.ReadKey().KeyChar-'0');
                if (opcion < 0 || opcion > 4)
                    Console.WriteLine("Esa opción no está en el menú");
            } while (opcion < 0 || opcion > 4);
            Console.Clear();
            return opcion;
        }
    }
}
