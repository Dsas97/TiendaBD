using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ClienteNuevo
    {
        [Required(ErrorMessage = "id Requerido")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Id Solo se permiten números.")]
        [Display(Name = "id")]
        public int idCliente { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "EL nombre solo permite letras.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Apellido Requerido")]
        [Display(Name = "Apellido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "EL apellido solo permite letras.")]
        public string apellidos { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "telefono")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Teléfono Solo se permiten números.")]
        public Nullable<int> telefono { get; set; }
    }
}