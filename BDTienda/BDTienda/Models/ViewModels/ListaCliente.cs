using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDTienda.Models.ViewModels
{
    public class ListaCliente
    {
        public int idCliente { get; set; }
        public string nombreCompleto { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public Nullable<int> telefono { get; set; }
    }
}