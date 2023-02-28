using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ListaProducto
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int idProv { get; set; }
    }
}