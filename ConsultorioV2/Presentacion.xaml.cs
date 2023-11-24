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
using System.Windows.Threading;

namespace ConsultorioV2
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Presentacion : Page
    {
        public Presentacion()
        {
            InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Reloj.Text = DateTime.Now.ToLongDateString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Reloj.Text = DateTime.Now.ToLongDateString();
        }

        private void BarraBusqueda_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(BarraBusqueda.Text))
            {
                BarraBusqueda.Text = "Buscar...";
            }
        }

        private void BarraBusqueda_GotFocus(object sender, RoutedEventArgs e)
        {
            if(BarraBusqueda.Text == "Buscar...")
            {
                BarraBusqueda.Text = "";
            }
        }

        public void cambiarContenido (string Pagina)
        {
            switch (Pagina)
            {
                case "txt_Doctores":
                    Titulo.Text = "Agenda de doctores";
                    break;
                case "txt_Pacientes":
                    Titulo.Text = "Agenda de pacientes";
                    break;
                case "txt_Citas":
                    Titulo.Text = "Agenda de citas";
                    break;
            }
        }
    }
}
