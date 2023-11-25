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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Rgb Menu (0,150,200)
    /// Animation Menu (0,200,200)
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            if (sender is TextBlock txtNombre)
            {
                Color_Rectangulos(txtNombre, Color.FromRgb(221, 242, 253), Color.FromRgb(66, 125, 157));
            }
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
            if (sender is TextBlock txtNombre)
            {
                Color_Rectangulos(txtNombre, Color.FromRgb(66, 125, 157), Color.FromRgb(221,242,253));
            }
        }

        private void TextBlock_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock txtNombre)
            {
                Presentacion presentacion = new Presentacion();
                switch (txtNombre.Name)
                {
                    case "txt_Inicio":
                        Rec_Pagina.NavigationService.Navigate(new Uri("Inicio.xaml", UriKind.Relative));
                        break;
                    default:
                        presentacion.cambiarContenido(txtNombre.Name);
                        Rec_Pagina.NavigationService.Navigate(presentacion);
                    break;
                }
            }
        }

        private void Color_Rectangulos(TextBlock txtNombre, Color rectangulo, Color letra)
        {
            switch (txtNombre.Name)
            {
                case "txt_Inicio":
                    Rec_Inicio.Fill = new SolidColorBrush(rectangulo);
                    txt_Inicio.Foreground = new SolidColorBrush(letra);
                    break;
                case "txt_Pacientes":
                    Rec_Pacientes.Fill = new SolidColorBrush(rectangulo);
                    txt_Pacientes.Foreground = new SolidColorBrush(letra);
                    break;
                case "txt_Doctores":
                    Rec_Doctores.Fill = new SolidColorBrush(rectangulo);
                    txt_Doctores.Foreground = new SolidColorBrush(letra);
                    break;
                case "txt_Citas":
                    Rec_Citas.Fill = new SolidColorBrush(rectangulo);
                    txt_Citas.Foreground = new SolidColorBrush(letra);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Reloj.Text = DateTime.Now.ToShortTimeString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Reloj.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
