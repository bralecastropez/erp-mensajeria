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
    using System.ComponentModel.DataAnnotations;

    public partial class RutaEntrega
    {
        public int ID_RutaEntrega { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Debe seleccionar la empresa")]
        public int ID_Empresa { get; set; }

        [Display(Name ="Proveedor")]
        [Required(ErrorMessage = "Debe seleccionar el proveedor")]
        public int ID_Proveedor { get; set; }

        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Orden")]
        [Required(ErrorMessage = "Debe seleccionar el orden")]
        public string ORDEN { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
