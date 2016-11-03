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
    /// Lógica de interacción para FrmLogin.xaml
    /// </summary>
    public partial class FrmLogin : Window
    {
        #region Variables

        #endregion

        #region Métodos
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            if (String.IsNullOrEmpty(this.txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es un campo requerido.", Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (String.IsNullOrEmpty(this.txtPassword.Password))
                MessageBox.Show("La clave de la cuenta es un campo requerido.", Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                usuario.Login = this.txtNombreUsuario.Text;
                usuario.Password = Helper.EncodePassword(this.txtPassword.Password);
                try
                {
                    var DatosUsuario = new UsuarioBC().AutentificarUsuario(usuario);
                    if (DatosUsuario != null)
                    {
                        MainWindow frmMain = new MainWindow();
                        frmMain.inicializarMainWindow(usuario);
                        frmMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña no son válidos", Variables.TituloMensaje,
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show(Variables.MsgError, Variables.TituloMensaje, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        #endregion
    }
}
