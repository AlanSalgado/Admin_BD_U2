using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Libro
    {
        private int id;
        private string isbn, titulo, autor, sinopsis, year, pais, edicion;

        public Libro(string isbn, string titulo, string autor, string sinopsis, string year, string pais, string edicion)
        {
            this.isbn = isbn; this.titulo=titulo; this.autor=autor; this.sinopsis=sinopsis; this.year=year; this.pais=pais; this.edicion = edicion;
        }

        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                titulo = value;
            }
        }

        public string Autor { 
            get
            {
                return autor;
            }
            set
            {
                autor = value;
            }
        }

        public string Sinopsis {
            get
            {
                return sinopsis;
            }
            set
            {
                sinopsis = value;
            }
        }

        public string AnioPublicacion {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public string PaisPublicacion {
            get
            {
                return pais;
            }
            set
            {
                pais = value;
            }
        }

        public string NumEdicion {
            get
            {
                return edicion;
            }
            set
            {
                edicion = value;
            }
        }

    }

}