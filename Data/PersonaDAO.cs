using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ClubDeportivoSystem.Models;

namespace ClubDeportivoSystem.Data
{
    public class PersonaDAO
    {
        // Insertar una nueva persona
        public bool InsertarPersona(Persona persona)
        {
            try
            {
                string query = @"INSERT INTO personas (nombre, apellido, dni, tipo_persona) 
                               VALUES (@nombre, @apellido, @dni, @tipo)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@nombre", persona.Nombre),
                    new MySqlParameter("@apellido", persona.Apellido),
                    new MySqlParameter("@dni", persona.DNI),
                    new MySqlParameter("@tipo", persona.TipoPersona)
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar persona: " + ex.Message);
            }
        }

        // Verificar si una persona existe por DNI
        public bool ExistePersona(string dni)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM personas WHERE dni = @dni";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@dni", dni)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de persona: " + ex.Message);
            }
        }

        // Obtener persona por DNI
        public Persona ObtenerPersonaPorDNI(string dni)
        {
            try
            {
                string query = "SELECT * FROM personas WHERE dni = @dni";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@dni", dni)
                };

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Persona
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = reader["dni"].ToString(),
                                    TipoPersona = reader["tipo_persona"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener persona: " + ex.Message);
            }
        }

        // Obtener todas las personas
        public List<Persona> ObtenerTodasLasPersonas()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                string query = "SELECT * FROM personas ORDER BY apellido, nombre";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                personas.Add(new Persona
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = reader["dni"].ToString(),
                                    TipoPersona = reader["tipo_persona"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener personas: " + ex.Message);
            }

            return personas;
        }

        // Obtener ID de la última persona insertada
        public int ObtenerUltimoId()
        {
            try
            {
                string query = "SELECT LAST_INSERT_ID()";
                object result = DatabaseConnection.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener último ID: " + ex.Message);
            }
        }
    }
}