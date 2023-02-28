using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class CompraCliente
    {
        public Clientes cliente { get; set; }
        public Compras compra { get; set; }
        public Producto producto { get; set; }
    }
}