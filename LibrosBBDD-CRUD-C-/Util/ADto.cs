using LibrosBBDD_CRUD_C_.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Util
{
    internal class ADto
    {
        public List<Libros> ResultadosLibros(NpgsqlDataReader resultado)
        {
            List<Libros> listaLibros = new List<Libros>();
            try
            {
                while (resultado.Read())
                {
                    listaLibros.Add(new Libros(long.Parse(resultado[0].ToString()), resultado[1].ToString(), resultado[2].ToString(), resultado[3].ToString(), Convert.ToInt32(resultado[4].ToString())));
                }
            }
            catch (Exception sqle)
            {
                Console.WriteLine("[ERROR-ADto-ResultadosLibros()]-No se ha podido leer el DataReader");
            }
            return listaLibros;
        }
    }
}
