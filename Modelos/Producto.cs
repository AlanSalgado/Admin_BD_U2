﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos {
    public class Producto {
        public string IDProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string FechaAdquisicion { get; set; }
        public string TipoAdquisicion { get; set; }
        public string Observaciones { get; set; }
        public int IDArea { get; set; }

        public Producto() { }

        public Producto(string idProd, string nombre, string descripcion, string serie, string color, string fechaAd, string tipoAd, string observaciones, int idArea) {
            IDProducto = idProd;
            Nombre = nombre;
            Descripcion = descripcion;
            Serie = serie;
            Color = color;
            FechaAdquisicion = fechaAd;
            TipoAdquisicion = tipoAd;
            Observaciones = observaciones;
            IDArea = idArea;
        }
    }
}
