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
    
    public partial class Oficina
    {
        public int ID_Oficina { get; set; }
        public int ID_Empresa { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
    
        public virtual Empresa Empresa { get; set; }
    }
}