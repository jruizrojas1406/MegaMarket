//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cibertec.MegaMarket.BL.BE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.DetallePedidoes = new HashSet<DetallePedido>();
        }
    
        public int IdPedido { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdFormaPago { get; set; }
        public Nullable<int> IdComprobante { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }
    }
}
