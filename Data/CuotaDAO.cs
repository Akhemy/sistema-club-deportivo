using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ClubDeportivoSystem.Models;

namespace ClubDeportivoSystem.Data
{
    public class CuotaDAO
    {
        // Registrar un nuevo pago para socios
        public bool RegistrarPago(int socioId, decimal monto, string tipoCuota, string medioPago = "Efectivo")
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
                            // 1. Insertar la cuota
                            string queryCuota = @"INSERT INTO cuotas 
                                                (socio_id, precio_cuota, fecha_vencimiento, fecha_pago, 
                                                 estado_cuota, medio_pago, tipo_cuota) 
                                                VALUES 
                                                (@socio_id, @precio_cuota, @fecha_vencimiento, @fecha_pago, 
                                                 'pagada', @medio_pago, @tipo_cuota)";

                            using (MySqlCommand cmdCuota = new MySqlCommand(queryCuota, connection, transaction))
                            {
                                DateTime fechaVencimiento;
                                if (tipoCuota.ToLower() == "mensual")
                                {
                                    fechaVencimiento = DateTime.Now.AddMonths(1);
                                }
                                else
                                {
                                    fechaVencimiento = DateTime.Now.AddDays(1);
                                }

                                cmdCuota.Parameters.AddWithValue("@socio_id", socioId);
                                cmdCuota.Parameters.AddWithValue("@precio_cuota", monto);
                                cmdCuota.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento);
                                cmdCuota.Parameters.AddWithValue("@fecha_pago", DateTime.Now);
                                cmdCuota.Parameters.AddWithValue("@medio_pago", medioPago);
                                cmdCuota.Parameters.AddWithValue("@tipo_cuota", tipoCuota.ToLower());

                                cmdCuota.ExecuteNonQuery();
                            }

                            // 2. Actualizar estado del socio
                            string querySocio = @"UPDATE socios 
                                                SET estado_cuota = 'al_dia', fecha_ultima_cuota = @fecha_pago 
                                                WHERE id = @socio_id";

                            using (MySqlCommand cmdSocio = new MySqlCommand(querySocio, connection, transaction))
                            {
                                cmdSocio.Parameters.AddWithValue("@fecha_pago", DateTime.Now);
                                cmdSocio.Parameters.AddWithValue("@socio_id", socioId);
                                cmdSocio.ExecuteNonQuery();
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
                throw new Exception("Error al registrar pago: " + ex.Message);
            }
        }

        // NUEVO: Registrar pago para no socios (cuota diaria)
        public bool RegistrarPagoNoSocio(int personaId, decimal monto, string metodoPago)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Insertar pago diario en tabla pagos_diarios
                    string queryPago = @"INSERT INTO pagos_diarios 
                                        (persona_id, monto, fecha_pago, fecha_acceso, medio_pago, estado) 
                                        VALUES 
                                        (@persona_id, @monto, @fecha_pago, @fecha_acceso, @medio_pago, 'pagado')";

                    using (MySqlCommand cmd = new MySqlCommand(queryPago, connection))
                    {
                        DateTime fechaActual = DateTime.Now;
                        DateTime fechaAcceso = fechaActual.Date.AddDays(1).AddSeconds(-1); // Válido hasta las 23:59:59 de hoy

                        cmd.Parameters.AddWithValue("@persona_id", personaId);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@fecha_pago", fechaActual);
                        cmd.Parameters.AddWithValue("@fecha_acceso", fechaAcceso);
                        cmd.Parameters.AddWithValue("@medio_pago", metodoPago);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar pago de no socio: " + ex.Message);
            }
        }

        // NUEVO: Verificar si un no socio tiene acceso válido para hoy
        public bool TieneAccesoValidoHoy(int personaId)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM pagos_diarios 
                               WHERE persona_id = @persona_id 
                               AND DATE(fecha_pago) = CURDATE() 
                               AND estado = 'pagado'";

                object result = DatabaseConnection.ExecuteScalar(query, new MySqlParameter[] {
                    new MySqlParameter("@persona_id", personaId)
                });

                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar acceso de no socio: " + ex.Message);
            }
        }

        // NUEVO: Obtener historial de pagos diarios de un no socio
        public List<object> ObtenerHistorialPagosNoSocio(int personaId)
        {
            List<object> pagos = new List<object>();

            try
            {
                string query = @"SELECT pd.*, p.nombre, p.apellido, p.dni 
                               FROM pagos_diarios pd
                               INNER JOIN personas p ON pd.persona_id = p.id 
                               WHERE pd.persona_id = @persona_id 
                               ORDER BY pd.fecha_pago DESC 
                               LIMIT 50"; // Limitar a los últimos 50 pagos

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@persona_id", personaId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pagos.Add(new
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    PersonaId = Convert.ToInt32(reader["persona_id"]),
                                    Monto = Convert.ToDecimal(reader["monto"]),
                                    FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                    FechaAcceso = Convert.ToDateTime(reader["fecha_acceso"]),
                                    MedioPago = reader["medio_pago"].ToString(),
                                    Estado = reader["estado"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = reader["dni"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener historial de no socio: " + ex.Message);
            }

            return pagos;
        }

        // NUEVO: Obtener estadísticas de pagos diarios
        public object ObtenerEstadisticasPagosDiarios(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                string query = @"SELECT 
                                   COUNT(*) as total_pagos,
                                   SUM(monto) as total_recaudado,
                                   COUNT(DISTINCT persona_id) as personas_distintas,
                                   AVG(monto) as promedio_pago
                               FROM pagos_diarios 
                               WHERE DATE(fecha_pago) BETWEEN @fecha_desde AND @fecha_hasta 
                               AND estado = 'pagado'";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fecha_desde", fechaDesde.Date);
                        command.Parameters.AddWithValue("@fecha_hasta", fechaHasta.Date);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new
                                {
                                    TotalPagos = Convert.ToInt32(reader["total_pagos"]),
                                    TotalRecaudado = reader["total_recaudado"] != DBNull.Value ?
                                                   Convert.ToDecimal(reader["total_recaudado"]) : 0m,
                                    PersonasDistintas = Convert.ToInt32(reader["personas_distintas"]),
                                    PromedioPago = reader["promedio_pago"] != DBNull.Value ?
                                                 Convert.ToDecimal(reader["promedio_pago"]) : 0m
                                };
                            }
                        }
                    }
                }

                // Si no hay datos, devolver valores por defecto
                return new
                {
                    TotalPagos = 0,
                    TotalRecaudado = 0m,
                    PersonasDistintas = 0,
                    PromedioPago = 0m
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estadísticas: " + ex.Message);
            }
        }

        // Obtener historial de pagos de un socio (método existente)
        public List<Cuota> ObtenerHistorialPagos(int socioId)
        {
            List<Cuota> cuotas = new List<Cuota>();

            try
            {
                string query = @"SELECT c.*, s.numero_socio, p.nombre, p.apellido 
                               FROM cuotas c 
                               INNER JOIN socios s ON c.socio_id = s.id 
                               INNER JOIN personas p ON s.persona_id = p.id 
                               WHERE c.socio_id = @socio_id 
                               ORDER BY c.fecha_pago DESC";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@socio_id", socioId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cuotas.Add(new Cuota
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    SocioId = Convert.ToInt32(reader["socio_id"]),
                                    PrecioCuota = Convert.ToDecimal(reader["precio_cuota"]),
                                    FechaVencimiento = Convert.ToDateTime(reader["fecha_vencimiento"]),
                                    FechaPago = reader["fecha_pago"] as DateTime?,
                                    EstadoCuota = reader["estado_cuota"].ToString(),
                                    MedioPago = reader["medio_pago"].ToString(),
                                    TipoCuota = reader["tipo_cuota"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener historial: " + ex.Message);
            }

            return cuotas;
        }

        // Obtener cuotas por vencer (método existente)
        public List<object> ObtenerCuotasPorVencer(DateTime fechaHasta)
        {
            List<object> sociosConVencimientos = new List<object>();

            try
            {
                string query = @"SELECT s.numero_socio, p.nombre, p.apellido, p.dni, 
                                       s.estado_cuota, s.fecha_ultima_cuota,
                                       CASE 
                                           WHEN s.fecha_ultima_cuota IS NULL THEN 'Nunca pagó'
                                           WHEN s.estado_cuota = 'al_dia' AND DATE_ADD(s.fecha_ultima_cuota, INTERVAL 30 DAY) <= @fecha_hasta THEN 'Por vencer'
                                           WHEN s.estado_cuota = 'vencida' THEN 'Vencida'
                                           ELSE 'Al día'
                                       END as situacion
                               FROM socios s 
                               INNER JOIN personas p ON s.persona_id = p.id 
                               WHERE (s.fecha_ultima_cuota IS NULL) 
                                  OR (s.estado_cuota = 'al_dia' AND DATE_ADD(s.fecha_ultima_cuota, INTERVAL 30 DAY) <= @fecha_hasta)
                                  OR (s.estado_cuota = 'vencida')
                               ORDER BY p.apellido, p.nombre";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fecha_hasta", fechaHasta);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sociosConVencimientos.Add(new
                                {
                                    NumeroSocio = Convert.ToInt32(reader["numero_socio"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    DNI = reader["dni"].ToString(),
                                    EstadoCuota = reader["estado_cuota"].ToString(),
                                    FechaUltimaCuota = reader["fecha_ultima_cuota"] as DateTime?,
                                    Situacion = reader["situacion"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener vencimientos: " + ex.Message);
            }

            return sociosConVencimientos;
        }

        // Verificar si un socio tiene cuotas pendientes (método existente)
        public bool TieneCuotasPendientes(int socioId)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM cuotas 
                               WHERE socio_id = @socio_id AND estado_cuota = 'pendiente'";

                object result = DatabaseConnection.ExecuteScalar(query, new MySqlParameter[] {
                    new MySqlParameter("@socio_id", socioId)
                });

                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar cuotas pendientes: " + ex.Message);
            }
        }
    }
}