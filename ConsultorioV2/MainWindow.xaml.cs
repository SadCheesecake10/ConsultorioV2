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
            if (sender is TextBlock txtNombre)
            {
                Color_Rectangulos(txtNombre, Color.FromRgb(0, 200, 200));
            }
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock txtNombre)
            {
                Color_Rectangulos(txtNombre, Color.FromRgb(0, 150, 200));
            }
        }

        private void Color_Rectangulos(TextBlock txtNombre, Color color)
        {
            switch (txtNombre.Name)
            {
                case "txt_Inicio":
                    Rec_Inicio.Fill = new SolidColorBrush(color);
                    break;
                case "txt_Pacientes":
                    Rec_Pacientes.Fill = new SolidColorBrush(color);
                    break;
                case "txt_Doctores":
                    Rec_Doctores.Fill = new SolidColorBrush(color);
                    break;
                case "txt_Citas":
                    Rec_Citas.Fill = new SolidColorBrush(color);
                    break;
            }
        }
    }
}
