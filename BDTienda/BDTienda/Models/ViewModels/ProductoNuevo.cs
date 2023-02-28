using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ProductoNuevo
    {
        [Required(ErrorMessage = "id Producto Requerido")]
        [Display(Name = "idProducto")]
        public int idProducto { get; set; }
        [Required(ErrorMessage = "id Proveedor Requerido")]
        [Display(Name = "idProveedor")]
        public int idProv { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Precio requerido")]
        [Display(Name = "Precio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public double precio { get; set; }
    }
}