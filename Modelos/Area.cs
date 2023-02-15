using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos {
    public class Area {
        public int IDArea { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public Area() { }

        public Area(int idArea, string nombre, string ubicacion) {
            IDArea = idArea;
            Nombre = nombre;
            Ubicacion = ubicacion;
        }
    }
}
