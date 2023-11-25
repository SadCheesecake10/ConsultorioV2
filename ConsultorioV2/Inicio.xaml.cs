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
using Npgsql;

namespace ConsultorioV2
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
        }

        #region Prueba de tabla
        struct Cita
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Motivo { get; set; }
            public string Hora { get; set; }
            public string Fecha { get; set; }
            public string Doctor { get; set; }

        }

        private List<Cita> listaCitas = new List<Cita>
        {
            new Cita { Nombre = "María", Apellido = "Gómez", Motivo = "Consulta general", Hora = "10:30", Fecha = "2023-12-01", Doctor = "Dr. Pérez" },
            new Cita { Nombre = "Juan", Apellido = "López", Motivo = "Examen médico", Hora = "15:45", Fecha = "2023-12-02", Doctor = "Dra. García" },
            new Cita { Nombre = "Sofía", Apellido = "Ramírez", Motivo = "Vacunación", Hora = "11:15", Fecha = "2023-12-03", Doctor = "Dr. Rodríguez" },
            new Cita { Nombre = "Diego", Apellido = "Fernández", Motivo = "Consulta general", Hora = "09:00", Fecha = "2023-12-04", Doctor = "Dra. Sánchez" },
            new Cita { Nombre = "Laura", Apellido = "Martínez", Motivo = "Seguimiento de tratamiento", Hora = "14:30", Fecha = "2023-12-05", Doctor = "Dr. Pérez" },
            new Cita { Nombre = "Carlos", Apellido = "Pérez", Motivo = "Chequeo rutinario", Hora = "16:00", Fecha = "2023-12-06", Doctor = "Dra. García" },
            new Cita { Nombre = "Isabel", Apellido = "Díaz", Motivo = "Examen médico", Hora = "10:45", Fecha = "2023-12-07", Doctor = "Dr. Rodríguez" },
            new Cita { Nombre = "Alejandro", Apellido = "Martínez", Motivo = "Consulta general", Hora = "13:15", Fecha = "2023-12-08", Doctor = "Dra. Sánchez" },
            new Cita { Nombre = "Ana", Apellido = "González", Motivo = "Vacunación", Hora = "11:30", Fecha = "2023-12-09", Doctor = "Dr. Pérez" },
            new Cita { Nombre = "Pedro", Apellido = "Rodríguez", Motivo = "Chequeo rutinario", Hora = "14:00", Fecha = "2023-12-10", Doctor = "Dra. García" },
            new Cita { Nombre = "María", Apellido = "López", Motivo = "Consulta general", Hora = "09:30", Fecha = "2023-12-11", Doctor = "Dr. Rodríguez" },
            new Cita { Nombre = "Diego", Apellido = "Gómez", Motivo = "Examen médico", Hora = "15:00", Fecha = "2023-12-12", Doctor = "Dra. Sánchez" },
            new Cita { Nombre = "Sofía", Apellido = "Pérez", Motivo = "Seguimiento de tratamiento", Hora = "12:45", Fecha = "2023-12-13", Doctor = "Dr. Pérez" },
            new Cita { Nombre = "Juan", Apellido = "Martínez", Motivo = "Vacunación", Hora = "10:15", Fecha = "2023-12-14", Doctor = "Dra. García" },
            new Cita { Nombre = "Carlos", Apellido = "Fernández", Motivo = "Chequeo rutinario", Hora = "13:30", Fecha = "2023-12-15", Doctor = "Dr. Rodríguez" },
            new Cita { Nombre = "Laura", Apellido = "Ramírez", Motivo = "Consulta general", Hora = "16:15", Fecha = "2023-12-16", Doctor = "Dra. Sánchez" },
            new Cita { Nombre = "Isabel", Apellido = "González", Motivo = "Examen médico", Hora = "09:45", Fecha = "2023-12-17", Doctor = "Dr. Pérez" },
            new Cita { Nombre = "Alejandro", Apellido = "Díaz", Motivo = "Vacunación", Hora = "11:00", Fecha = "2023-12-18", Doctor = "Dra. García" },
            new Cita { Nombre = "Ana", Apellido = "Rodríguez", Motivo = "Seguimiento de tratamiento", Hora = "14:45", Fecha = "2023-12-19", Doctor = "Dr. Rodríguez" },
            new Cita { Nombre = "Pedro", Apellido = "Martínez", Motivo = "Chequeo rutinario", Hora = "12:00", Fecha = "2023-12-20", Doctor = "Dra. Sánchez" }
        };
        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Reloj.Text = DateTime.Now.ToLongDateString();

            LlenarTablaPrueba();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Reloj.Text = DateTime.Now.ToLongDateString();
        }

        private void LlenarTablaPrueba()
        {
            listaCitas = listaCitas.OrderBy(cita => cita.Fecha).ThenBy(cita => cita.Hora).ToList();
            TablaCitas.ItemsSource = listaCitas;
        }

        private void TablaCitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void citas_de_Hoy()
        {
           List<Cita> citas = new List<Cita>();
            try
            {
                string cadenaConexion = "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=Consultorio";
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();
                string sql = "SELECT Pacientes.Nombre, Pacientes.Apellido, Doctores.Nombre, Citas.Fecha, Citas.TipoCita" +
                    "FROM Relaciones" +
                    "INNER JOIN Pacientes ON Relaciones.PacienteId = Pacientes.Id" +
                    "INNER JOIN Doctores ON Relaciones.DoctorId = Doctores.Id" +
                    "INNER JOIN Citas ON Relaciones.CitaId = Citas.Id;";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-mm-dd"));
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cita cita = new Cita();
                    cita.Nombre = reader.GetString(1);
                    cita.Apellido = reader.GetString(2);
                    cita.Motivo = reader.GetString(3);
                    cita.Hora = reader.GetString(4);
                    cita.Fecha = reader.GetString(5);
                    cita.Doctor = reader.GetString(6);
                    citas.Add(cita);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            TablaCitas.ItemsSource = citas;
        }
    }
}
