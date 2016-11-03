using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.UI.App.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cibertec.MegaMarket.UI.App.Form
{
    /// <summary>
    /// Lógica de interacción para FrmVentas.xaml
    /// </summary>
    public partial class FrmVentas : Window
    {
        #region Métodos
        public FrmVentas()
        {
            InitializeComponent();
            inicializarComboBox();
        }

        public class PedidoItem
        {
            public int Codigo { set; get; }
            public string Descripcion { set; get; }
            public decimal Precio { set; get; }
            public int Cantidad { set; get; }
            public decimal Subtotal { set; get; }
        }

        private void inicializarComboBox()
        {
            //Poblar Tipo Comprobante
            List<TipoComprobante> tipoComprobante = new List<TipoComprobante>();
            tipoComprobante = new TipoComprobanteBC().ListarTipoComprobante();
            tipoComprobante.Add(new TipoComprobante { IdComprobante = 0, Nombre = "-- Seleccionar --" });
            this.cboTipoComprobante.ItemsSource = tipoComprobante;
            this.cboTipoComprobante.DisplayMemberPath = "Nombre";
            this.cboTipoComprobante.SelectedValuePath = "IdComprobante";

            //Poblar Forma de pago
            List<FormaPago> formaPago = new List<FormaPago>();
            formaPago = new FormaPagoBC().ListarFormaPago();
            formaPago.Add(new FormaPago { IdFormaPago = 0, Nombre = "-- Seleccionar --" });
            this.cboFormaPago.ItemsSource = formaPago;
            this.cboFormaPago.DisplayMemberPath = "Nombre";
            this.cboFormaPago.SelectedValuePath = "IdFormaPago";

            //Poblar Tipo de Moneda
            List<Moneda> TipoMoneda = new List<Moneda>();
            TipoMoneda = new MonedaBC().ListarMoneda();
            TipoMoneda.Add(new Moneda { IdMoneda = 0, Nombre = "-- Seleccionar --" });
            this.cboMoneda.ItemsSource = TipoMoneda;
            this.cboMoneda.DisplayMemberPath = "Nombre";
            this.cboMoneda.SelectedValuePath = "IdMoneda";

            this.cboTipoComprobante.SelectedValue = 0;
            this.cboFormaPago.SelectedValue = 0;
            this.cboMoneda.SelectedValue = 0;
        }
        #endregion

        #region Eventos
        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.InicializarModoLectura();
            bool? result = frmCliente.ShowDialog();
            if (result ?? false)
            {
                var cliente = frmCliente.entCliente;
                this.txtCodCliente.Text = frmCliente.entCliente.IdCliente.ToString();
                this.txtNombreCliente.Text = String.Format("{0} {1}", cliente.Nombres, cliente.Apellidos);
                this.txtDocItentidad.Text = cliente.DocIdentidad;
                this.txtDireccion.Text = cliente.Direccion;
            }
        }

        private void btnBuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.InicializarModoLectura();
            bool? result = frmProducto.ShowDialog();
            if (result ?? false)
            {
                var producto = frmProducto.entProducto;
                this.txtCodProducto.Text = producto.IdProducto.ToString();
                this.txtDProducto.Text = producto.Nombre;
                this.txtPrecio.Text = producto.Precio.ToString();
            }
        }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPrecio.Text) && !String.IsNullOrEmpty(this.txtCantidad.Text))
            {
                decimal obtenerSubTotal = Convert.ToDecimal(this.txtPrecio.Text) * Convert.ToInt32(this.txtCantidad.Text);
                this.txtSubtotal.Text = obtenerSubTotal.ToString("0.##");
            }
        }

        private void btnAdicionarProducto_Click(object sender, RoutedEventArgs e)
        {
            double igv = 0.18;
            decimal TotalImpuesto;
            decimal TotalVenta;
            //DetallePedido detallePedido = new DetallePedido();
            //detallePedido.IdProducto = Convert.ToInt32(this.txtCodProducto.Text);
            //detallePedido.Producto.Descripcion = this.txtDProducto.Text;
            //detallePedido.Precio = Convert.ToDecimal(this.txtPrecio.Text);
            //detallePedido.Cantidad = Convert.ToInt32(this.txtCantidad.Text);
            //detallePedido.Pedido.SubTotal = Convert.ToDecimal(this.txtSubtotal.Text);
            //this.dgProductos.Items.Add(detallePedido);


            dgProductos.Items.Add(
                new PedidoItem
                {
                    Codigo = Convert.ToInt32(txtCodProducto.Text),
                    Descripcion = txtDProducto.Text,
                    Precio = Convert.ToDecimal(this.txtPrecio.Text),
                    Cantidad = Convert.ToInt32(this.txtCantidad.Text),
                    Subtotal = Convert.ToDecimal(this.txtSubtotal.Text)
                });

            // Calculo del Neto
            decimal suma = 0;
            foreach (var item in dgProductos.Items)
            {
                suma = suma + (decimal)((PedidoItem)item).Subtotal;
            }

            lblNeto.Content = suma;            
            TotalVenta = suma+(suma - Convert.ToDecimal(lblDescuento.Content)) * (decimal)igv;
            TotalImpuesto = (suma - Convert.ToDecimal(lblDescuento.Content)) * (decimal)igv;
            lblTotal.Content = TotalVenta.ToString();

            //Limpiar controles
            txtCodProducto.Text = "";
            txtDProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtSubtotal.Text = "";

            txtCodProducto.Focus();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            decimal suma = 0;
            double igv = 0.18;
            decimal TotalImpuesto;
            decimal TotalVenta;

            try
            {
                Pedido pedido = new Pedido();
                pedido.IdCliente = Convert.ToInt32(this.txtCodCliente.Text);
                pedido.IdEmpleado = 1;
                pedido.IdComprobante = Convert.ToInt32(this.cboTipoComprobante.SelectedValue);
                pedido.IdFormaPago = Convert.ToInt32(this.cboFormaPago.SelectedValue);
                pedido.IdMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
                pedido.Fecha = System.DateTime.Now;

                List<DetallePedido> listDetallePedido = new List<DetallePedido>();
                foreach (var item in dgProductos.Items)
                {
                    suma = suma + (decimal)((PedidoItem)item).Subtotal;

                    DetallePedido detPedido = new DetallePedido();
                    detPedido.IdProducto = ((PedidoItem)item).Codigo;
                    detPedido.Cantidad = ((PedidoItem)item).Cantidad;
                    detPedido.Precio = ((PedidoItem)item).Precio;
                    detPedido.Importe = ((PedidoItem)item).Subtotal;
                    listDetallePedido.Add(detPedido);
                }

                TotalImpuesto = (suma - Convert.ToDecimal(lblDescuento.Content)) * (decimal)igv;
                TotalVenta = suma + TotalImpuesto;
                pedido.Impuesto = TotalImpuesto;
                pedido.SubTotal = suma;
                pedido.Total = TotalVenta;

                new PedidoBC().InsertarPedido(pedido, listDetallePedido);
                MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje, MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #endregion


    }
}
