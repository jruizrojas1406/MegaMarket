﻿using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.UI.App.Clases;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para MantProducto.xaml
    /// </summary>
    public partial class FrmMantProducto : Window
    {
        public string Operacion { get; set; }

        public FrmMantProducto()
        {
            InitializeComponent();
            inicializarComboBox();
        }

        private void inicializarComboBox()
        {
            //Poblar Categoria
            List<Categoria> categoria = new List<Categoria>();
            categoria = new CategoriaBC().ListarCategorias("");
            categoria.Add(new Categoria { IdCategoria = 0, Nombre = "-- Seleccionar --" });
            this.cboCategoria.ItemsSource = categoria;
            this.cboCategoria.DisplayMemberPath = "Nombre";
            this.cboCategoria.SelectedValuePath = "IdCategoria";

            //Poblar Marca     
            List<Marca> marca = new List<Marca>();
            marca = new MarcaBC().ListarMarca();
            marca.Add(new Marca { IdMarca = 0, Nombre = "-- Seleccionar --" });
            this.cboMarca.ItemsSource = marca;
            this.cboMarca.DisplayMemberPath = "Nombre";
            this.cboMarca.SelectedValuePath = "IdMarca";

            //Poblar Unidad de Medida
            List<UnidMedida> unidMedida = new List<UnidMedida>();
            unidMedida = new UnidadMedidaBC().ListarUnidadMedida();
            unidMedida.Add(new UnidMedida { IdUnidMedida = 0, Nombre = "-- Seleccionar --" });
            this.cboUmedida.ItemsSource = unidMedida;
            this.cboUmedida.DisplayMemberPath = "Nombre";
            this.cboUmedida.SelectedValuePath = "IdUnidMedida";

            this.cboCategoria.SelectedValue = 0;
            this.cboMarca.SelectedValue = 0;
            this.cboUmedida.SelectedValue = 0;
        }

        public void agregarNuevoProducto()
        {
            this.Operacion = "INS";
            limpiarFormulario();
        }

        public void editarProducto(Producto producto)
        {
            this.Operacion = "UPD";
            limpiarFormulario();
            this.txtCodigo.Text = producto.IdProducto.ToString();
            this.txtNombre.Text = producto.Nombre;
            this.txtDescripcion.Text = producto.Descripcion;
            this.cboCategoria.SelectedValue = producto.IdCategoria;
            this.cboUmedida.SelectedValue = producto.IdUnidMedida;
            this.cboMarca.SelectedValue = producto.IdMarca;
            this.txtStock.Text = producto.Stock.ToString();
            this.txtPrecio.Text = producto.Precio.ToString();
        }

        private void limpiarFormulario()
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtDescripcion.Clear();
            //this.cboCategoria.SelectedIndex
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            ProductoBC productoBC = new ProductoBC();
            Producto producto = new Producto();

            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
                producto.IdProducto = Convert.ToInt32(this.txtCodigo.Text);
            producto.Nombre = this.txtNombre.Text;
            producto.Descripcion = this.txtDescripcion.Text;
            producto.IdCategoria = Convert.ToInt32(this.cboCategoria.SelectedValue.ToString());
            producto.IdUnidMedida = Convert.ToInt32(this.cboUmedida.SelectedValue.ToString());
            producto.IdMarca = Convert.ToInt32(this.cboMarca.SelectedValue.ToString());
            producto.Stock = Convert.ToInt32(this.txtStock.Text);
            producto.Precio = Convert.ToDecimal(this.txtPrecio.Text);

            try
            {
                if (Operacion.Equals("UPD"))
                    productoBC.ActualizarProducto(producto);
                else
                    productoBC.InsertarProducto(producto);
                MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Information);

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
