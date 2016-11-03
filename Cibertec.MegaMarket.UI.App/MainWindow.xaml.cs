using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.UI.App.Form;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cibertec.MegaMarket.UI.App
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Usuario DatosLoginUsuario { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void inicializarMainWindow(Usuario usuario)
        {
            DatosLoginUsuario = new Usuario();
            DatosLoginUsuario.Login = usuario.Login;
            DatosLoginUsuario.IdUsuario = usuario.IdUsuario;
        }

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            try
            {
                frmProducto.ShowDialog();
            }
            finally
            {
                if (frmProducto != null)
                {
                    //btnProducto.Background = Brushes.Transparent;
                    //btnProducto.Background = new SolidColorBrush(Color.FromArgb(0,0,0,0));
                }
            }
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            FrmVentas frmVentas = new FrmVentas();
            try
            {
                frmVentas.ShowDialog();
            }
            finally
            {
                if (frmVentas != null)
                {
                }
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            try
            {
                frmCliente.ShowDialog();
            }
            finally
            {
                if (frmCliente != null)
                {
                }
            }
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado();
            try
            {
                frmEmpleado.ShowDialog();
            }
            finally
            {
                if (frmEmpleado != null)
                {
                }
            }
        }

        private void btnConsultarVentas_Click(object sender, RoutedEventArgs e)
        {
            FrmConsultarVentas frmConsultarVentas = new FrmConsultarVentas();
            try
            {
                frmConsultarVentas.ShowDialog();
            }
            finally
            {
                if (frmConsultarVentas != null)
                {
                }
            }
        }
    }
}
