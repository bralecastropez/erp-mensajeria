using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Mensajeria.Models
{
    public class ListUtil
    {
        public Estado estado { get; set; }
        public TipoEntrada tipoEntrada { get; set; }
        public Anticipada anticipada { get; set; }
        public Elevador elevador { get; set; }
        public Aprobado aprobado { get; set; }
        public EstadoEntrega estadoEntrega { get; set; }
        public Orden orden { get; set; }
    }

    public enum Estado
    {
        Activo,
        Inactivo
    }

    public enum TipoEntrada
    {
        Entrada,
        Salida
    }

    public enum Anticipada
    {
        Si,
        No
    }

    public enum Elevador
    {
        Si,
        No
    }

    public enum Aprobado
    {
        Si,
        No
    }

    public enum EstadoEntrega
    {
        Espera,
        Entregado,
        Accesando,
        Saliendo
    }

    public enum Orden
    {
        Ascendente,
        Descendente
    }

}