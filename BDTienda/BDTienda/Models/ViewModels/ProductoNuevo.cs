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
        [RegularExpression("^[0-9]+$", ErrorMessage = "Producto Solo se permiten números.")]
        [Display(Name = "idProducto")]
        public int idProducto { get; set; }
        [Required(ErrorMessage = "id Proveedor Requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Proveedor Solo se permiten números.")]
        [Display(Name = "idProveedor")]
        public int idProv { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "EL nombre solo permite letras.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Precio requerido")]
        [Display(Name = "Precio")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        //[Range(0, 999.99)]
        public double precio { get; set; }
    }
}