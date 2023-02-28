using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class CompraNueva
    {
        public int idCompra { get; set; }
        [Required]
        [Display(Name = "idCliente")]
        public int idCliente { get; set; }
        [Required]
        [Display(Name = "idProducto")]
        public int idProducto { get; set; }

        public List<Clientes> Clientes { get; set; }
        public List<Producto> Productos { get; set; }
    }
}