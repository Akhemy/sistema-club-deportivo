using System;

namespace ClubDeportivoSystem.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public string NumeroCarnet { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Activo { get; set; }

        // Propiedades de navegación
        public Socio Socio { get; set; }

        public Carnet()
        {
            FechaEmision = DateTime.Now;
            Activo = true;
            NumeroCarnet = GenerarNumeroCarnet();
        }

        public Carnet(int socioId)
        {
            SocioId = socioId;
            FechaEmision = DateTime.Now;
            FechaVencimiento = DateTime.Now.AddYears(1);
            Activo = true;
            NumeroCarnet = GenerarNumeroCarnet();
        }

        private string GenerarNumeroCarnet()
        {
            // Generar número de carnet único basado en timestamp
            return $"CARNET{DateTime.Now:yyyyMMddHHmmss}";
        }

        public bool EstaVencido => FechaVencimiento.HasValue && DateTime.Now > FechaVencimiento.Value;
        public bool EstaVigente => Activo && (!FechaVencimiento.HasValue || DateTime.Now <= FechaVencimiento.Value);
    }
}