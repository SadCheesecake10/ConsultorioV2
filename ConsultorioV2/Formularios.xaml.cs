using ConsultorioV2.Clases;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConsultorioV2
{
    /// <summary>
    /// Interaction logic for Formularios.xaml
    /// </summary>
    public partial class Formularios : Window
    {
        public Formularios()
        {
            InitializeComponent();
        }

        private async void Buscar_Click(object sender, RoutedEventArgs e)
        {
            DIPOMEX_API direccion = new DIPOMEX_API();
            string CP = CodigoPostal.Text;
            string url = "codigo_postal?cp=" + CP;
            string resultado = await direccion.GetCall(url);
            try
            { 
                if(resultado != null)
                {
                    RespuestaAPI respuesta = JsonConvert.DeserializeObject<RespuestaAPI>(resultado);

                    llenarCampos(respuesta.direccion.municipio,respuesta.direccion.estado_abreviatura, respuesta.direccion.colonias);
                }
                else
                {
                    MessageBox.Show("No se encontro el codigo postal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void llenarCampos(string Municipio, string Estado, List<string> listaColonias)
        {
            cb_Colonias.Items.Clear();
            tb_Municipio.Text = Municipio;
            tb_Estado.Text = Estado;
            foreach (string colonia in listaColonias)
            {
                cb_Colonias.Items.Add(colonia);
            }

            if (cb_Colonias.Items.Count > 0)
            {
                cb_Colonias.SelectedIndex = 0;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidarCampo(tf_Nombre.Text, "Nombre");
                ValidarCampo(tf_ApPaterno.Text, "Apellido Paterno");
                ValidarCampo(tf_ApMaterno.Text, "Apellido Materno");
                if(Titulo.Text == "Agregar Doctor")
                {
                  ValidarCampo(tf_Cedula.Text, "Cedula", 8);
                }
                ValidarCampo(tf_Telefono.Text, "Telefono", 10);
                ValidarCampo(CodigoPostal.Text, "Codigo Postal", 5);
                ValidarCampo(tf_Calle.Text, "Calle");
                ValidarCampo(tf_Numero.Text, "Numero");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarCampo(string valor, string nombreCampo, int longitud = 0)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new Exception($"El campo -{nombreCampo}- no puede estar vacío");
            }

            if (longitud > 0 && valor.Length != longitud)
            {
                throw new Exception($"El campo -{nombreCampo}- debe tener {longitud} caracteres");
            }
        }

        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}
