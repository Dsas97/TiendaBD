using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ClienteNuevo
    {
        [Required]
        [Display(Name = "id")]
        public int idCliente { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellidos { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "telefono")]
        public Nullable<int> telefono { get; set; }
    }
}