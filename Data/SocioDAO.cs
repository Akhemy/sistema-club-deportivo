using System;
using MySql.Data.MySqlClient;
using ClubDeportivoSystem.Models;

namespace ClubDeportivoSystem.Data
{
    public class SocioDAO
    {
        // Insertar un nuevo socio
        public bool InsertarSocio(int personaId)
        {
            try
            {
                // Generar número de socio automático
                int numeroSocio = GenerarNumeroSocio();

                string query = @"INSERT INTO socios (persona_id, numero_socio, estado_cuota) 
                               VALUES (@persona_id, @numero_socio, @estado_cuota)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@persona_id", personaId),
                    new MySqlParameter("@numero_socio", numeroSocio),
                    new MySqlParameter("@estado_cuota", "pendiente")
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar socio: " + ex.Message);
            }
        }

        // Generar número de socio automático
        private int GenerarNumeroSocio()
        {
            try
            {
                string query = "SELECT IFNULL(MAX(numero_socio), 0) + 1 FROM socios";
                object result = DatabaseConnection.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar número de socio: " + ex.Message);
            }
        }

        // Obtener socio por persona ID
        public Socio ObtenerSocioPorPersonaId(int personaId)
        {
            try
            {
                string query = @"SELECT s.*, p.nombre, p.apellido, p.dni 
                               FROM socios s 
                               INNER JOIN personas p ON s.persona_id = p.id 
                               WHERE s.persona_id = @persona_id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@persona_id", personaId)
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
                                return new Socio
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    PersonaId = Convert.ToInt32(reader["persona_id"]),
                                    NumeroSocio = Convert.ToInt32(reader["numero_socio"]),
                                    EstadoCuota = reader["estado_cuota"].ToString(),
                                    FechaUltimaCuota = reader["fecha_ultima_cuota"] as DateTime?,
                                    Persona = new Persona
                                    {
                                        Id = personaId,
                                        Nombre = reader["nombre"].ToString(),
                                        Apellido = reader["apellido"].ToString(),
                                        DNI = reader["dni"].ToString()
                                    }
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener socio: " + ex.Message);
            }
        }

        // Insertar un no socio
        public bool InsertarNoSocio(int personaId)
        {
            try
            {
                string query = @"INSERT INTO no_socios (persona_id, actividades_realizadas) 
                               VALUES (@persona_id, 0)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@persona_id", personaId)
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar no socio: " + ex.Message);
            }
        }
    }
}