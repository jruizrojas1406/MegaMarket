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
    
    public partial class sp_ListarProductos_Result
    {
        public int IdProducto { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdUnidMedida { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public Nullable<int> IdMoneda { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Stock { get; set; }
        public string UnidMedidaDescripcion { get; set; }
    }
}