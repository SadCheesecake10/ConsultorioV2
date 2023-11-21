using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConsultorioV2.Datos
{
    internal class Datos_Pacientes
    {
        static string cadenaConexion = "Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=Consultorio";
        static NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
        public static List<Clases.Paciente> ObtenerPacientes()
        {
            List<Clases.Paciente> pacientes = new List<Clases.Paciente>();
            try
            {
                conexion.Open();
                string sql = "SELECT * FROM paciente";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clases.Paciente paciente = new Clases.Paciente();
                    paciente.Id = reader.GetInt32(0);
                    paciente.Nombre = reader.GetString(1);
                    paciente.ApellidoPaterno = reader.GetString(2);
                    paciente.ApellidoMaterno = reader.GetString(3);
                    paciente.Telefono = reader.GetInt32(4);
                    pacientes.Add(paciente);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return pacientes;
        }

        public static void AgregarPaciente(Clases.Paciente paciente)
        {
            try
            {
                conexion.Open();
                string sql = "INSERT INTO paciente(nombre, apellido_paterno, apellido_materno, telefono) VALUES(@nombre, @apellido_paterno, @apellido_materno, @telefono)";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                comando.Parameters.AddWithValue("@apellido_paterno", paciente.ApellidoPaterno);
                comando.Parameters.AddWithValue("@apellido_materno", paciente.ApellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", paciente.Telefono);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarPaciente(int id)
        {
            try
            {
                conexion.Open();
                string sql = "DELETE FROM paciente WHERE id = @id";
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

        public static void ActualizarPaciente(Clases.Paciente paciente)
        {
            try
            {
                conexion.Open();
                string sql = "UPDATE paciente SET nombre = @nombre, apellido_paterno = @apellido_paterno, apellido_materno = @apellido_materno, telefono = @telefono WHERE id = @id";
                NpgsqlCommand comando = new NpgsqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", paciente.Id);
                comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                comando.Parameters.AddWithValue("@apellido_paterno", paciente.ApellidoPaterno);
                comando.Parameters.AddWithValue("@apellido_materno", paciente.ApellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", paciente.Telefono);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void BuscarPaciente(string criterio)
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
