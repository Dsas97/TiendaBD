using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ProveedorNuevo
    {
        [Required]
        [Display(Name = "idProveedor")]
        public int idProv { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
    }
}