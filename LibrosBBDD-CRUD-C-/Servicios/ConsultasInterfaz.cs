using LibrosBBDD_CRUD_C_.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    /// <summary>
    /// Interfaz que define métodos para el CRUD de la BBDD.
    /// </summary>
    internal interface ConsultasInterfaz
    {
        /// <summary>
        /// Método para mostrar los libros que existen en la BBDD.
        /// </summary>
        /// <param name="conexion"></param>
        void MostrarLibros(NpgsqlConnection conexion);
        /// <summary>
        /// Método para cambiar los datos de un registro de libro de la BBDD.
        /// </summary>
        /// <param name="conexion"></param>
        void ActualizarLibros(NpgsqlConnection conexion);
        /// <summary>
        /// Método para insertar/crear un nuevo registro de libro en la BBDD.
        /// </summary>
        /// <param name="conexion"></param>
        void CrearLibros(NpgsqlConnection conexion);
        /// <summary>
        /// Método para borrar un registro de libro de la BBDD. 
        /// </summary>
        /// <param name="conexion"></param>
        void BorrarLibros(NpgsqlConnection conexion);
    }
}
