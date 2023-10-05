using LibrosBBDD_CRUD_C_.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrosBBDD_CRUD_C_.Util;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    internal class ConsultasImplementacion:ConsultasInterfaz
    {   
        public void MostrarLibros(NpgsqlConnection conexion)
        {
            int opcion;
            long id_libro;
            Herramientas herr = new Herramientas();
            List<Libros> listaLibrosCrear = new List<Libros>();
            NpgsqlCommand consulta = null;
            NpgsqlDataReader resultado = null;
            ADto aDto = new ADto();
            try
            {
                consulta = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros\r\n" + "ORDER BY id_libro ASC ",conexion);
                resultado = consulta.ExecuteReader();
                listaLibrosCrear = aDto.ResultadosLibros(resultado);
                consulta.Dispose();
                resultado.Close();
                conexion.Close();
                if (listaLibrosCrear.Count() == 0)
                    Console.WriteLine("[INFO-ConsultaImplementación-MostrarLibros()]-No hay registrado ningún libro.");
                else
                {
                    
                    Console.Write("Introduce 1 para mostrar todos los libros y 2 para mostrar un libro concreto-->");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 1)
                    {
                        Console.WriteLine("---LISTA DE LIBROS---");
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            Console.WriteLine(listaLibrosCrear[i].toString());
                        }
                        herr.Pausa();
                        Console.Clear();
                    }
                    else if (opcion == 2)
                    {
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            Console.WriteLine(listaLibrosCrear[i].Id_libro + "." + listaLibrosCrear[i].Titulo);
                        }
                        Console.Write("Introduce el id del libro que quiera mostrar-->");
                        id_libro = long.Parse(Console.ReadLine());
                        Console.WriteLine("---LIBRO SELECCIONADO---");
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            if (listaLibrosCrear[i].Id_libro == id_libro)
                                Console.WriteLine(listaLibrosCrear[i].toString());
                        }
                        herr.Pausa();
                        Console.Clear();
                    }
                    Console.Clear();
                }
            }
            catch (Exception sqle)
            {
                Console.WriteLine("[ERROR-ConsultaImplementacion-MostrarLibros()]-No se ha podido acceder a la base de datos.");
                conexion.Close();
            }
        }
        public void BorrarLibros(NpgsqlConnection conexion)
        {

        }
        public void CrearLibros(NpgsqlConnection conexion)
        {
            throw new NotImplementedException();
        }
        public void ActualizarLibros(NpgsqlConnection conexion)
        {

        }
    }
}
