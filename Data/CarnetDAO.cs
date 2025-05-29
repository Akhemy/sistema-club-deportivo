using System;
using MySql.Data.MySqlClient;
using ClubDeportivoSystem.Models;

namespace ClubDeportivoSystem.Data
{
    public class CarnetDAO
    {
        // Insertar un nuevo carnet
        public bool InsertarCarnet(Carnet carnet, int socioId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Desactivar carnets anteriores del mismo socio
                            string queryDesactivar = @"UPDATE carnets SET activo = 0 WHERE socio_id = @socio_id";

                            using (MySqlCommand cmdDesactivar = new MySqlCommand(queryDesactivar, connection, transaction))
                            {
                                cmdDesactivar.Parameters.AddWithValue("@socio_id", socioId);
                                cmdDesactivar.ExecuteNonQuery();
                            }

                            // 2. Insertar nuevo carnet
                            string queryInsertar = @"INSERT INTO carnets 
                                                    (socio_id, numero_carnet, fecha_emision, fecha_vencimiento, activo) 
                                                    VALUES 
                                                    (@socio_id, @numero_carnet, @fecha_emision, @fecha_vencimiento, 1)";

                            using (MySqlCommand cmdInsertar = new MySqlCommand(queryInsertar, connection, transaction))
                            {
                                cmdInsertar.Parameters.AddWithValue("@socio_id", socioId);
                                cmdInsertar.Parameters.AddWithValue("@numero_carnet", carnet.NumeroCarnet);
                                cmdInsertar.Parameters.AddWithValue("@fecha_emision", carnet.FechaEmision);
                                cmdInsertar.Parameters.AddWithValue("@fecha_vencimiento", carnet.FechaVencimiento);

                                cmdInsertar.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar carnet: " + ex.Message);
            }
        }

        // Verificar si un socio tiene carnet activo
        public bool TieneCarnetActivo(int socioId)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM carnets 
                               WHERE socio_id = @socio_id AND activo = 1";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@socio_id", socioId)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar carnet activo: " + ex.Message);
            }
        }

        // Obtener carnet activo de un socio
        public Carnet ObtenerCarnetActivo(int socioId)
        {
            try
            {
                string query = @"SELECT c.*, s.numero_socio, p.nombre, p.apellido, p.dni 
                               FROM carnets c 
                               INNER JOIN socios s ON c.socio_id = s.id 
                               INNER JOIN personas p ON s.persona_id = p.id 
                               WHERE c.socio_id = @socio_id AND c.activo = 1 
                               ORDER BY c.fecha_emision DESC 
                               LIMIT 1";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@socio_id", socioId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Carnet
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    SocioId = Convert.ToInt32(reader["socio_id"]),
                                    NumeroCarnet = reader["numero_carnet"].ToString(),
                                    FechaEmision = Convert.ToDateTime(reader["fecha_emision"]),
                                    FechaVencimiento = reader["fecha_vencimiento"] as DateTime?,
                                    Activo = Convert.ToBoolean(reader["activo"])
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener carnet: " + ex.Message);
            }
        }

        // Desactivar carnet
        public bool DesactivarCarnet(int carnetId)
        {
            try
            {
                string query = "UPDATE carnets SET activo = 0 WHERE id = @carnet_id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@carnet_id", carnetId)
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactivar carnet: " + ex.Message);
            }
        }

        // Obtener carnets por vencer
        public System.Collections.Generic.List<object> ObtenerCarnetsPorVencer(int diasAntes = 30)
        {
            System.Collections.Generic.List<object> carnetsVencimiento = new System.Collections.Generic.List<object>();

            try
            {
                string query = @"SELECT c.numero_carnet, c.fecha_vencimiento, 
                                       s.numero_socio, p.nombre, p.apellido, p.dni,
                                       DATEDIFF(c.fecha_vencimiento, CURDATE()) as dias_para_vencer
                               FROM carnets c 
                               INNER JOIN socios s ON c.socio_id = s.id 
                               INNER JOIN personas p ON s.persona_id = p.id 
                               WHERE c.activo = 1 
                                 AND c.fecha_vencimiento IS NOT NULL 
                                 AND DATEDIFF(c.fecha_vencimiento, CURDATE()) <= @dias_antes
                                 AND DATEDIFF(c.fecha_vencimiento, CURDATE()) >= 0
                               ORDER BY c.fecha_vencimiento";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dias_antes", diasAntes);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                carnetsVencimiento.Add(new
                                {
                                    NumeroCarnet = reader["numero_carnet"].ToString(),
                                    FechaVencimiento = Convert.ToDateTime(reader["fecha_vencimiento"]),
                                    NumeroSocio = Convert.ToInt32(reader["numero_socio"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = reader["dni"].ToString(),
                                    DiasParaVencer = Convert.ToInt32(reader["dias_para_vencer"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener carnets por vencer: " + ex.Message);
            }

            return carnetsVencimiento;
        }
    }
}
