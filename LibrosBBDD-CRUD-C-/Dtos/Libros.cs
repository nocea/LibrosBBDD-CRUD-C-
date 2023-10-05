using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibrosBBDD_CRUD_C_.Dtos
{
    internal class Libros
    {
        //Atributos
        private long id_libro;
        private string autor;
        private string titulo;
        private string isbn;
        private int edicion;

        public Libros()
        {
        }
        //Constructores
        public Libros(long id_libro, string autor, string titulo, string isbn, int edicion)
        {
            this.id_libro = id_libro;
            this.autor = autor;
            this.titulo = titulo;
            this.isbn = isbn;
            this.edicion = edicion;
        }
        //Getters & Setters
        public long Id_libro { get => id_libro; set => id_libro = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public int Edicion { get => edicion; set => edicion = value; }
        public string toString()
        {
            return "Libros [id_libro=" + id_libro + ", titulo=" + titulo + ", autor=" + autor + ", isbn=" + isbn
                + ", edicion=" + edicion + "]";
        }
    }
}
