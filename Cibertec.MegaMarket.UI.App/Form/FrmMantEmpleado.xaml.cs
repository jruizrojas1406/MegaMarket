using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.BL.BC;
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
using Cibertec.MegaMarket.UI.App.Clases;

namespace Cibertec.MegaMarket.UI.App.Form
{
    /// <summary>
    /// Interaction logic for FrmMantEmpleado.xaml
    /// </summary>
    public partial class FrmMantEmpleado : Window
    {

        public string Operacion { get; set; }

        public FrmMantEmpleado()
        {
            InitializeComponent();
            inicializarComboBox();
        }

        private void inicializarComboBox()
        {
            //Poblar Cargo
            List<Cargo> cargo = new List<Cargo>();
            cargo = new CargoBC().ListarCargo();
            cargo.Add(new Cargo { IdCargo = 0, Nombre = "-- Seleccionar --" });
            this.cboCargo.ItemsSource = cargo;
            this.cboCargo.DisplayMemberPath = "Nombre";
            this.cboCargo.SelectedValuePath = "IdCargo";
            this.cboCargo.SelectedValue = 0;
        }

        public void agregarNuevoEmpleado()
        {
            this.Operacion = "INS";
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoBC empleadoBC = new EmpleadoBC();
            Empleado empleado = new Empleado();

            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
                empleado.IdEmpleado = Convert.ToInt32(this.txtCodigo.Text);

            empleado.Nombres = this.txtNombres.Text;
            empleado.Apellidos = this.txtApellidos.Text;
            empleado.IdCargo = Convert.ToInt32(this.cboCargo.SelectedValue.ToString()); ;
            try
            {
                if (Operacion.Equals("UPD"))
                    empleadoBC.ActualizarEmpleado(empleado);
                else
                    empleadoBC.InsertarEmpleado(empleado);
                MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje,MessageBoxButton.OK, MessageBoxImage.Information);

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void editarEmpleado(Empleado empleado)
        {
            this.Operacion = "UPD";
            this.txtCodigo.Text = empleado.IdEmpleado.ToString();
            this.txtNombres.Text = empleado.Nombres;
            this.txtApellidos.Text = empleado.Apellidos;
            this.cboCargo.SelectedValue = empleado.IdCargo;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
