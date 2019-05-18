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

    public partial class Oficina
    {
        public int ID_Oficina { get; set; }

        [Display(Name = "Empresa")]
        [DisplayName("Empresa")]
        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        public int ID_Empresa { get; set; }

        [StringLength(20)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la oficina")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Detalle { get; set; }

        [DefaultValue("Activo")]
        [StringLength(8, MinimumLength = 6)]
        public string Estado { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
