using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrosBBDD_CRUD_C_.Servicios
{
    /// <summary>
    /// Interfaz que define métodos para conectar con BBDD.
    /// </summary>
    internal interface ConexionInterfaz
    {
        /// <summary>
        /// Método que abre la conexión con la BBDD.
        /// </summary>
        /// <returns></returns>
        NpgsqlConnection Conectar();
    }
}
