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
    /// Interaction logic for FrmEmpleado.xaml
    /// </summary>
    public partial class FrmEmpleado : Window
    {

        #region Variables
        public Empleado entEmpleado { get; set; }
        #endregion

        #region Métodos
        public FrmEmpleado()
        {
            InitializeComponent();
            llenarEmpleados(this.txtNombreEmpleado.Text);
        }

        private void llenarEmpleados(string NombreEmpleado)
        {
            EmpleadoBC empleadoBC = new EmpleadoBC();
            try
            {
                dgEmpleados.ItemsSource = empleadoBC.ListarEmpleados(NombreEmpleado);
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgErrorAplicacion, Variables.TituloMensaje,MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Eventos
        private void btnNuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            FrmMantEmpleado frmMantEmpleado = new FrmMantEmpleado();
            frmMantEmpleado.agregarNuevoEmpleado();
            bool? result = frmMantEmpleado.ShowDialog();
            if (result ?? false)
                llenarEmpleados(this.txtNombreEmpleado.Text);
        }

        private void dgCellBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button CellBtnEditar = sender as Button;
            Empleado empleado = CellBtnEditar.DataContext as Empleado;
            FrmMantEmpleado frmMantEmpleado = new FrmMantEmpleado();
            frmMantEmpleado.editarEmpleado(empleado);
            bool? result = frmMantEmpleado.ShowDialog();
            if (result ?? false)
                llenarEmpleados(this.txtNombreEmpleado.Text);
        }

        private void dgCellBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = (sender as Button).DataContext as Empleado;
            MessageBoxResult resultado = MessageBox.Show(Variables.MsgConfirmacion, Variables.TituloMensaje,MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                try
                {
                    EmpleadoBC empleadoBC = new EmpleadoBC();
                    empleadoBC.EliminarEmpleado(empleado.IdEmpleado);
                    MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje, MessageBoxButton.OK,MessageBoxImage.Information);
                    llenarEmpleados(this.txtNombreEmpleado.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBuscarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            llenarEmpleados(this.txtNombreEmpleado.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgCellBtnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            Button dgCellBtnCargarDatos = sender as Button;
            entEmpleado = dgEmpleados.DataContext as Empleado;
            this.DialogResult = true;
        }
        #endregion
    }
}
