using LibrosBBDD_CRUD_C_.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    internal interface ConsultasInterfaz
    {
        void MostrarLibros(NpgsqlConnection conexion);
        void ActualizarLibros(NpgsqlConnection conexion);
        void CrearLibros(NpgsqlConnection conexion);
        void BorrarLibros(NpgsqlConnection conexion);
    }
}
