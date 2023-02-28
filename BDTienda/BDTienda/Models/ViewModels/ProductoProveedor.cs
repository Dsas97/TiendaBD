using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ProductoProveedor
    {
        public Producto product { get; set; }
        public Proveedor provee { get; set; }
    }
}