using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
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

namespace Cibertec.MegaMarket.UI.Desktop.Form
{
    /// <summary>
    /// Lógica de interacción para MantProducto.xaml
    /// </summary>
    public partial class MantProducto : Window
    {
        public MantProducto()
        {
            InitializeComponent();
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            //Poblar Categoria
            cboCategoria.ItemsSource = new CategoriaBC().ListarCategorias("");
            cboCategoria.DisplayMemberPath = "Nombre";
            cboCategoria.SelectedValuePath = "IdCategoria";

            //Poblar Marca
            cboMarca.ItemsSource = new MarcaBC().ListarMarca();
            cboMarca.DisplayMemberPath = "Nombre";
            cboMarca.SelectedValuePath = "IdMarca";

            //Poblar Unidad deMedida
            cboUmedida.ItemsSource = new UnidadMedidaBC().ListarUnidadMedida();
            cboUmedida.DisplayMemberPath = "Nombre";
            cboUmedida.SelectedValuePath = "IdUnidadMedida";
        }
    }
}
