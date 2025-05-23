using System;

namespace ClubDeportivoSystem.Models
{
    public class Cuota
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public decimal PrecioCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaPago { get; set; }
        public string EstadoCuota { get; set; }
        public string MedioPago { get; set; }
        public string TipoCuota { get; set; }

        // Propiedades de navegación
        public Socio Socio { get; set; }

        public Cuota()
        {
            EstadoCuota = "pendiente";
            TipoCuota = "mensual";
        }

        public bool EstaPagada => EstadoCuota == "pagada";
        public bool EstaVencida => DateTime.Now > FechaVencimiento && EstadoCuota != "pagada";
    }
}