﻿using LibrosBBDD_CRUD_C_.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrosBBDD_CRUD_C_.Util;
using System.Runtime.InteropServices;
using System.Xml;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    /// <summary>
    /// Implementación de los métodos CRUD para BBDD PostgreSQL
    /// </summary>
    internal class ConsultasImplementacion : ConsultasInterfaz
    {
        public void MostrarLibros(NpgsqlConnection conexion)
        {
            int opcion;
            long id_libro;
            Herramientas hr = new Herramientas();
            List<Libros> listaLibrosCrear = new List<Libros>();
            NpgsqlCommand consulta = null;
            NpgsqlDataReader resultado = null;
            ADto aDto = new ADto();
            try
            {
                //Genero la consulta y guardo los registros en una lista provisional.
                consulta = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros\r\n" + "ORDER BY id_libro ASC ", conexion);
                resultado = consulta.ExecuteReader();
                listaLibrosCrear = aDto.ResultadosLibros(resultado);
                consulta.Dispose();
                resultado.Close();
                conexion.Close();
                if (listaLibrosCrear.Count() == 0)//Si está vacía la lista.
                    Console.WriteLine("[INFO-ConsultasImplementación-MostrarLibros()]-No hay registrado ningún libro.");
                else
                { 
                    Console.Write("Introduce 1 para mostrar todos los libros y 2 para mostrar un libro concreto-->");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (opcion == 1)//Todos los libros
                    {
                        Console.WriteLine("---LISTA DE LIBROS---");
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            Console.WriteLine(listaLibrosCrear[i].toString());
                        }
                        hr.Pausa();
                        
                    }
                    else if (opcion == 2)//Un solo libro
                    {
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            Console.WriteLine(listaLibrosCrear[i].Id_libro + "." + listaLibrosCrear[i].Titulo);
                        }
                        Console.Write("Introduce el id del libro que quiera mostrar-->");
                        id_libro = long.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("---LIBRO SELECCIONADO---");
                        for (int i = 0; i < listaLibrosCrear.Count(); i++)
                        {
                            if (listaLibrosCrear[i].Id_libro == id_libro)
                                Console.WriteLine(listaLibrosCrear[i].toString());
                        }
                        hr.Pausa();
                    }
                }
            }
            catch (NpgsqlException sqle)
            {
                Console.WriteLine("[ERROR-ConsultasImplementacion-MostrarLibros()]-No se ha podido acceder a la base de datos.");
                conexion.Close();
            }
        }
        public void BorrarLibros(NpgsqlConnection conexion)
        {
            int idLibroBorrado = -1;
            NpgsqlCommand consulta = null;
            NpgsqlDataReader resultado = null;
            List<Libros> listaLibrosBorrar = new List<Libros>();
            Herramientas hr = new Herramientas();
            ADto aDto = new ADto();          
            try
            {
                //Muestro todos los libros y su id.
                consulta = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros\r\n" + "ORDER BY id_libro ASC ", conexion);
                resultado = consulta.ExecuteReader();
                listaLibrosBorrar = aDto.ResultadosLibros(resultado);
                for (int i = 0; i < listaLibrosBorrar.Count(); i++)
                {
                    Console.WriteLine(listaLibrosBorrar[i].Id_libro + "." + listaLibrosBorrar[i].Titulo);
                }
                consulta = null;
                resultado.Close();
                Console.Write("Introduzca el id del libro que quiere borrar-->");//Pido id del libro a borrar.
                idLibroBorrado = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            catch (NpgsqlException sqle)
            {
                Console.WriteLine("[ERROR-ConsultasImplementación-BorrarLibros()]-No se ha podido acceder a la base de datos.");
            }
            try
            {
                //Borro segín el id_libro antes introducido.
                consulta = new NpgsqlCommand("DELETE FROM gbp_almacen.gbp_alm_cat_libros\r\n" + "WHERE id_libro = @id_libro", conexion);
                consulta.Parameters.AddWithValue("@id_libro",idLibroBorrado);
                consulta.ExecuteNonQuery();
                consulta.Dispose();
                conexion.Close();
                Console.WriteLine("[INFO-ConsultasImplementación-BorrarLibros()]-Se ha borrado el libro correctamente.");
                hr.Pausa();
            }
            catch (NpgsqlException sqle)
            {
                Console.WriteLine("[ERROR-ConsultasImplementación-BorrarLibros()]-No se ha podido borrar el libro.");
            }
        }
        public void CrearLibros(NpgsqlConnection conexion)
        {
            int numLibrosCreados, edicion = 0;
            String titulo = "", autor = "", isbn = "";
            List<Libros> listaLibrosCrear = new List<Libros>();
            NpgsqlCommand consulta = null;
            Herramientas hr = new Herramientas();
            Console.Write("Introduzca el numero de libros que quiere crear-->");//Pido el número de libros que quiera crear.
            numLibrosCreados = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            
            
            for (int i = 0; i < numLibrosCreados; i++)
            {
                Console.WriteLine("--Iniciando creación de libros--");
                Console.WriteLine("(Si no quiere crear más libros introduzca 0 en el campo de titulo)");
                Console.WriteLine("--------Libro: " + (i + 1) + "--------");
                Console.Write("Introduce el titulo del nuevo libro-->");
                titulo = Console.ReadLine();
                if (titulo=="0")//Si introduce 0 en el titulo
                    break;//Se para la creación
                Console.Write("Introduce el autor del nuevo libro-->");
                autor = Console.ReadLine();
                Console.Write("Introduce el isbn del nuevo libro-->");
                isbn = Console.ReadLine();
                Console.Write("Introduce la edición del nuevo libro-->");
                edicion = Convert.ToInt32(Console.ReadLine());
                listaLibrosCrear.Add(new Libros(titulo, autor, isbn, edicion));//Guardo un nuevo libro
                Console.Clear();
            }
            try
            {
                for (int i = 0; i < listaLibrosCrear.Count(); i++)
                {
                    //Inserto y guardo.
                    consulta = new NpgsqlCommand("INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo,autor,isbn,edicion)\r\n"
                                    + "VALUES (@titulo,@autor,@isbn,@edicion);", conexion);
                    consulta.Parameters.AddWithValue("@titulo", listaLibrosCrear[i].Titulo);
                    consulta.Parameters.AddWithValue("@autor", listaLibrosCrear[i].Autor);
                    consulta.Parameters.AddWithValue("@isbn", listaLibrosCrear[i].Isbn);
                    consulta.Parameters.AddWithValue("@edicion", listaLibrosCrear[i].Edicion);
                    consulta.ExecuteNonQuery();
                }
                consulta.Dispose();
                conexion.Close();
                Console.WriteLine("[INFO-ConsultasImplementación-CrearLibros()]-Se han guardado todos los libros en la base de datos");
                hr.Pausa();
            }
            catch (NpgsqlException sqle)
            {
                Console.WriteLine("[ERROR-ConsultasImplementación-CrearLibros()]-No se ha podido acceder a la base de datos.");
            }
        }
        public void ActualizarLibros(NpgsqlConnection conexion)
        {
            List<Libros> listaLibrosUpdate = new List<Libros>();
            NpgsqlCommand consulta = null;
            NpgsqlDataReader resultado = null;
            Herramientas hr = new Herramientas();
            ADto aDto = new ADto();
            long id_libro;
            int edicion;
            String titulo, autor, isbn;
            try
            {
                //Muestro todos los libros con su id.
                consulta = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros\r\n" + "ORDER BY id_libro ASC ", conexion);
                resultado = consulta.ExecuteReader();
                listaLibrosUpdate = aDto.ResultadosLibros(resultado);
                for (int i = 0; i < listaLibrosUpdate.Count(); i++)
                {
                    Console.WriteLine(listaLibrosUpdate[i].Id_libro + "." + listaLibrosUpdate[i].Titulo);
                }
                resultado.Close();
                consulta = null;
                if (listaLibrosUpdate.Count() == 0)
                    Console.WriteLine("[INFO-ConsultasImplementación-ActualizarLibros()]-No hay registrado ningún libro.");
                else
                {
                    //Pido los nuevos datos del libro seleccionado.
                    Console.Write("Introduzca el id del libro del que quiera editar sus datos--> ");
                    id_libro = long.Parse(Console.ReadLine());
                    Console.Write("Actualiza el titulo-->");
                    titulo = Console.ReadLine();
                    Console.Write("Actualiza el autor-->");
                    autor = Console.ReadLine();
                    Console.Write("Actualiza el isbn-->");
                    isbn = Console.ReadLine();
                    Console.Write("Actualiza la edición-->");
                    edicion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    //Genero la consulta con los nuevos datos.
                    consulta = new NpgsqlCommand("UPDATE gbp_almacen.gbp_alm_cat_libros SET titulo = @titulo,autor= @autor,isbn= @isbn,edicion= @edicion WHERE id_libro = @id_libro;", conexion);
                    consulta.Parameters.AddWithValue("@titulo", titulo);  
                    consulta.Parameters.AddWithValue("@autor", autor);
                    consulta.Parameters.AddWithValue("@isbn", isbn);
                    consulta.Parameters.AddWithValue("@edicion", edicion);
                    consulta.Parameters.AddWithValue("@id_libro", id_libro);
                    consulta.ExecuteNonQuery();
                    consulta.Dispose();
                    conexion.Close();
                    Console.WriteLine("[INFO-ConsultasImplementación-ActualizarLibros()]-Se han actualizado los datos del libro");
                    hr.Pausa();
                }
            }
            catch (NpgsqlException sqle)
            {
                Console.WriteLine("[ERROR-ConsultasImplemencacion-ActualizarLibros()]-No se ha podido acceder a la base de datos.");
            }
        }
    }
}
