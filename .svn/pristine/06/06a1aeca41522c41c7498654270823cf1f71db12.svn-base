using Cibertec.MegaMarket.BL.BC;
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
    /// Lógica de interacción para FrmMantCliente.xaml
    /// </summary>
    public partial class FrmMantCliente : Window
    {
        public string Operacion { get; set; }

        public FrmMantCliente()
        {
            InitializeComponent();
            inicializarComboBox();
        }

        private void inicializarComboBox()
        {
            //Poblar Pais
            List<Pai> pais = new List<Pai>();
            pais = new UbigeoBC().ListarPaises();
            pais.Add(new Pai { IdPais = 0, Nombre = "-- Seleccionar --" });
            this.cboPais.ItemsSource = pais;
            this.cboPais.DisplayMemberPath = "Nombre";
            this.cboPais.SelectedValuePath = "IdPais";
            this.cboPais.SelectedValue = 0;
        }

        public void agregarNuevoCliente()
        {
            this.Operacion = "INS";
        }

        public void editarCliente(Cliente cliente)
        {
            this.Operacion = "UPD";
            this.txtCodigo.Text = cliente.IdCliente.ToString();
            this.txtNombres.Text = cliente.Nombres;
            this.txtApellidos.Text = cliente.Apellidos;
            this.txtTelFijo.Text = cliente.Telfijo;
            this.txtTelMovil.Text = cliente.TelMovil;
            this.txtDireccion.Text = cliente.Direccion;
            this.txtDocIdentidad.Text = cliente.DocIdentidad;
            this.txtEmail.Text = cliente.Email;
            this.cboPais.SelectedValue = cliente.IdPais;
            if (cliente.IdPais > 0)
            {
                PoblarListaCiudades((int)cliente.IdPais);
                this.cboCiudad.SelectedValue = cliente.IdCiudad;
            }

            if (cliente.IdPais > 0 && cliente.IdCiudad > 0)
            {
                PoblarListaDistritos((int)cliente.IdPais, (int)cliente.IdCiudad);
                this.cboDistrito.SelectedValue = cliente.IdDistrito;
            }

        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            ClienteBC clienteBC = new ClienteBC();
            Cliente cliente = new Cliente();

            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
                cliente.IdCliente = Convert.ToInt32(this.txtCodigo.Text);

            cliente.Nombres = this.txtNombres.Text;
            cliente.Apellidos = this.txtApellidos.Text;
            cliente.Telfijo = this.txtTelFijo.Text;
            cliente.TelMovil = this.txtTelMovil.Text;
            cliente.Direccion = this.txtDireccion.Text;
            cliente.DocIdentidad = this.txtDocIdentidad.Text;
            cliente.Email = this.txtEmail.Text;
            cliente.IdPais = Convert.ToInt32(this.cboPais.SelectedValue.ToString()); ;
            cliente.IdCiudad = Convert.ToInt32(this.cboCiudad.SelectedValue.ToString());
            cliente.IdDistrito = Convert.ToInt32(this.cboDistrito.SelectedValue.ToString());
            try
            {
                if (Operacion.Equals("UPD"))
                    clienteBC.ActualizarCliente(cliente);
                else
                    clienteBC.InsertarCliente(cliente);
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

        private void cboPais_DropDownClosed(object sender, EventArgs e)
        {
            string CodPais = this.cboPais.SelectedValue.ToString();
            this.cboCiudad.ItemsSource = new List<Ciudad>();
            this.cboCiudad.IsEnabled = false;
            this.cboDistrito.ItemsSource = new List<Distrito>();
            this.cboDistrito.IsEnabled = false;
            if (CodPais.Equals("0")) return;

            PoblarListaCiudades(Convert.ToInt32(CodPais));
        }

        private void cboCiudad_DropDownClosed(object sender, EventArgs e)
        {
            int CodPais = Convert.ToInt32(this.cboPais.SelectedValue.ToString());
            string CodCiudad = this.cboCiudad.SelectedValue.ToString();
            this.cboDistrito.ItemsSource = new List<Distrito>();
            this.cboDistrito.IsEnabled = false;
            if (CodCiudad.Equals("0")) return;
            PoblarListaDistritos(CodPais, Convert.ToInt32(CodCiudad));
        }

        private void PoblarListaCiudades(int CodPais)
        {
            //Poblar Ciudad     
            List<Ciudad> ciudad = new List<Ciudad>();
            ciudad = new UbigeoBC().ListarCiudad(CodPais);
            ciudad.Add(new Ciudad { IdCiudad = 0, Nombre = "-- Seleccionar --" });
            this.cboCiudad.ItemsSource = ciudad;
            this.cboCiudad.DisplayMemberPath = "Nombre";
            this.cboCiudad.SelectedValuePath = "IdCiudad";
            this.cboCiudad.SelectedValue = 0;
            this.cboCiudad.IsEnabled = true;
        }

        private void PoblarListaDistritos(int CodPais, int CodCiudad)
        {
            //Poblar Distrito
            List<Distrito> distrito = new List<Distrito>();
            distrito = new UbigeoBC().ListarDistrito(CodPais, CodCiudad);
            distrito.Add(new Distrito { IdDistrito = 0, Nombre = "-- Seleccionar --" });
            this.cboDistrito.ItemsSource = distrito;
            this.cboDistrito.DisplayMemberPath = "Nombre";
            this.cboDistrito.SelectedValuePath = "IdDistrito";
            this.cboDistrito.SelectedValue = 0;
            this.cboDistrito.IsEnabled = true;
        }
    }
}
