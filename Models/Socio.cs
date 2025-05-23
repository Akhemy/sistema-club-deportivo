using System;

namespace ClubDeportivoSystem.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int NumeroSocio { get; set; }
        public string EstadoCuota { get; set; }
        public DateTime? FechaUltimaCuota { get; set; }

        // Propiedades de navegación
        public Persona Persona { get; set; }

        public Socio()
        {
            EstadoCuota = "pendiente";
        }

        public bool CuotaAlDia => EstadoCuota == "al_dia";
        public bool CuotaVencida => EstadoCuota == "vencida";
    }
}