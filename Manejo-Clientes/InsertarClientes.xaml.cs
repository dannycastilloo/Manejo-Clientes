using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Manejo_Clientes
{
    /// <summary>
    /// Lógica de interacción para InsertarClientes.xaml
    /// </summary>
    public partial class InsertarClientes : Window
    {
        public InsertarClientes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string idCliente = txtIdCliente.Text;
            string nombrecompania = txtNombreCompania.Text;
            string nombrecontacto = txtNombreContacto.Text;
            string cargocontacto = txtCargoContacto.Text;
            string direccion = txtDireccion.Text;
            string ciudad = txtCiudad.Text;
            string region = txtRegion.Text;
            string codpostal = txtCodPostal.Text;
            string pais = txtPais.Text;
            string telefono = txtTelefono.Text;
            string fax = txtFax.Text;

            try
            {
                string connectionString = "Data Source=LAB1504-06\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=Danny;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("InsertarClientes", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@nombrecompania", nombrecompania);
                            cmd.Parameters.AddWithValue("@nombrecontacto", nombrecontacto);
                            cmd.Parameters.AddWithValue("@cargocontacto", cargocontacto);
                            cmd.Parameters.AddWithValue("@direccion", direccion);
                            cmd.Parameters.AddWithValue("@ciudad", ciudad);
                            cmd.Parameters.AddWithValue("@region", region);
                            cmd.Parameters.AddWithValue("@codpostal", codpostal);
                            cmd.Parameters.AddWithValue("@pais", pais);
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@fax", fax);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cliente ingresado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ingresar el cliente: " + ex.Message);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
