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
        [Required(ErrorMessage = "id Cliente Requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Cliente Solo se permiten números.")]
        [Display(Name = "idCliente")]
        public int idCliente { get; set; }
        [Required(ErrorMessage = "id Producto Requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Producto Solo se permiten números.")]
        [Display(Name = "idProducto")]
        public int idProducto { get; set; }

        public List<Clientes> Clientes { get; set; }
        public List<Producto> Productos { get; set; }
    }
}