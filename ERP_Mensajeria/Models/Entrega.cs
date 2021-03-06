//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Mensajeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Entrega
    {
        public int ID_Entrega { get; set; }

        [DisplayName("Empresa")]
        [Required(ErrorMessage = "Debe seleccionar la empresa")]
        public int ID_Empresa { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Debe seleccionar el proveedor")]
        public int ID_Proveedor { get; set; }

        [DisplayName("Contacto")]
        [Required(ErrorMessage = "Debe seleccionar al contacto")]
        public int ID_Contacto { get; set; }

        [DisplayName("Número de paquetes")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ingresar un número válido")]
        [Required(ErrorMessage = "Debe ingresar el número de paquetes")]
        public Nullable<int> No_Paquetes { get; set; }

        [DefaultValue("No")]
        [StringLength(2, MinimumLength = 2)]
        [Required(ErrorMessage = "Debe seleccionar si se anticipará")]
        public string Anticipada { get; set; }
    
        public virtual Contacto Contacto { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
