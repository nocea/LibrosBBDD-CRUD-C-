using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Servicios
{
    /// <summary>
    /// Interfaz para el controlador de la aplicación.
    /// </summary>
    internal interface ProgramInterfaz
    {
        /// <summary>
        /// Método que muestra las opciones de un menú,pide una opción por consola y la devuelve.
        /// </summary>
        /// <returns></returns>
        int Menu();
    }
}
