using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosBBDD_CRUD_C_.Util
{
    /// <summary>
    /// Clase que tiene métodos para poder usarlos en cualquier parte de la aplicación
    /// </summary>
    internal class Herramientas
    {
        /// <summary>
        /// Método simple para poder dar más claridad a cada paso al usuario.
        /// </summary>
        public void Pausa()
        {
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
