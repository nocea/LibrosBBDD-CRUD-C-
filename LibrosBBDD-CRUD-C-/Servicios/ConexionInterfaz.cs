using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrosBBDD_CRUD_C_.Servicios
{
    internal interface ConexionInterfaz
    {
        NpgsqlConnection Conectar();
    }
}
