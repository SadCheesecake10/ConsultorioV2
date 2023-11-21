using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConsultorioV2.Datos
{
    internal class Datos_Doctores
    {
        static string cadenaConexion = "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=Consultorio";
        static NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
        public static List<Clases.Doctor> ObtenerDoctores()
        {
            List<Clases.Doctor> doctores = new List<Clases.Doctor>();
            try
            {
                conexion.Open();
                string sql = "SELECT * FROM doctor";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clases.Doctor doctor = new Clases.Doctor();
                    doctor.Id = reader.GetInt32(0);
                    doctor.Nombre = reader.GetString(1);
                    doctor.ApellidoPaterno = reader.GetString(2);
                    doctor.ApellidoMaterno = reader.GetString(3);
                    doctor.Telefono = reader.GetInt32(4);
                    doctores.Add(doctor);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return doctores;
        }

        public static void AgregarDoctor(Clases.Doctor doctor)
        {
            try
            {
                conexion.Open();
                string sql = "INSERT INTO doctor(nombre, apellido_paterno, apellido_materno, telefono) VALUES(@nombre, @apellido_paterno, @apellido_materno, @telefono)";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre);
                comando.Parameters.AddWithValue("@apellido_paterno", doctor.ApellidoPaterno);
                comando.Parameters.AddWithValue("@apellido_materno", doctor.ApellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", doctor.Telefono);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EliminarDoctor(int id)
        {
            try
            {
                conexion.Open();
                string sql = "DELETE FROM doctor WHERE id = @id";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ModificarDoctor(Clases.Doctor doctor)
        {
            try
            {
                conexion.Open();
                string sql = "UPDATE doctor SET nombre = @nombre, apellido_paterno = @apellido_paterno, apellido_materno = @apellido_materno, telefono = @telefono WHERE id = @id";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", doctor.Id);
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre);
                comando.Parameters.AddWithValue("@apellido_paterno", doctor.ApellidoPaterno);
                comando.Parameters.AddWithValue("@apellido_materno", doctor.ApellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", doctor.Telefono);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void BuscarDoctor(string criterio)
        {
            try
            {
                conexion.Open();
                string sql = "SELECT * FROM paciente WHERE nombre = @criterio OR ap_paterno = @criterio OR ap_materno = @criterio OR CONCAT(nombre, ' ', ap_paterno, ' ', ap_materno) = @criterio OR id = @id";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@criterio", criterio);

                if (int.TryParse(criterio, out int id))
                {
                    comando.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    comando.Parameters.Remove("@id");
                }
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
