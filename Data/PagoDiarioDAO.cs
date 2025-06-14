using System;
using MySql.Data.MySqlClient;
using ClubDeportivoSystem.Models;

namespace ClubDeportivoSystem.Data
{
    public class PagoDiarioDAO
    {
        // Registrar pago de no socio en pagos_diarios
        public bool RegistrarPagoNoSocio(int personaId, decimal monto, string tipoCuota, string medioPago = "Efectivo", string observaciones = "")
        {
            try
            {
                string query = @"INSERT INTO pagos_diarios 
                                (persona_id, monto, fecha_pago, fecha_acceso, medio_pago, estado, observaciones, created_at, updated_at) 
                                VALUES 
                                (@persona_id, @monto, @fecha_pago, @fecha_acceso, @medio_pago, 'pagado', @observaciones, NOW(), NOW())";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@persona_id", personaId),
                    new MySqlParameter("@monto", monto),
                    new MySqlParameter("@fecha_pago", DateTime.Now),
                    new MySqlParameter("@fecha_acceso", DateTime.Now),
                    new MySqlParameter("@medio_pago", medioPago),
                    new MySqlParameter("@observaciones", $"Pago {tipoCuota} - {observaciones}")
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar pago diario: " + ex.Message);
            }
        }

        // Actualizar actividades realizadas del no socio
        public bool ActualizarActividadesNoSocio(int personaId)
        {
            try
            {
                string query = @"UPDATE no_socios 
                                SET actividades_realizadas = actividades_realizadas + 1 
                                WHERE persona_id = @persona_id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@persona_id", personaId)
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar actividades de no socio: " + ex.Message);
            }
        }
    }
}