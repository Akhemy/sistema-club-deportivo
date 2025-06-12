using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivoSystem.Data
{
    public class DatabaseConnection
    {
        // Cadena de conexión para XAMPP (sin contraseña por defecto)
       // private static string connectionString = "Server=localhost;Port=3306;Database=club_deportivo;Uid=root;Pwd=;";
        private static string connectionString = null;
        

        // Método para actualizar la cadena de conexión
        public static void SetConnectionString(string server, string port, string database, string username, string password)
        {
            connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
        }

        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Método para ejecutar consultas SELECT
        public static MySqlDataReader ExecuteReader(string query, MySqlParameter[] parameters = null)
        {
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            connection.Open();
            return command.ExecuteReader();
        }

        // Método para ejecutar INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message);
            }
        }

        // Método para obtener un valor único (COUNT, MAX, etc.)
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message);
            }
        }
    }
}