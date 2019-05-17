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

    public partial class Nivel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nivel()
        {
            this.Empresa = new HashSet<Empresa>();
        }
    
        public int ID_Nivel { get; set; }
        public int ID_Edificio { get; set; }

        [StringLength(20)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre del tipo de usuario")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Detalle { get; set; }

        [DefaultValue("Activo")]
        [StringLength(8, MinimumLength = 6)]
        public string Estado { get; set; }
    
        public virtual Edificio Edificio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}