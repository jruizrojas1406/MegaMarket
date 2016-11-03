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
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.DetallePedidoes = new HashSet<DetallePedido>();
        }
    
        public int IdProducto { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdUnidMedida { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Stock { get; set; }
        public byte[] Foto { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual UnidMedida UnidMedida { get; set; }
    }
}