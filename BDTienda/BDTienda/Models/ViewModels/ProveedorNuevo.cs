using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ProveedorNuevo
    {
        [Required(ErrorMessage = "id Proveedor Requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Proveedor Solo se permiten números.")]
        [Display(Name = "idProveedor")]
        public int idProv { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "EL nombre solo permite letras.")]
        public string nombre { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
    }
}