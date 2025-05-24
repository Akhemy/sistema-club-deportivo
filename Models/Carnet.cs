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

        public Carnet()
        {
            FechaEmision = DateTime.Now;
            Activo = true;
        }

        public Carnet(int socioId, string numeroCarnet) : this()
        {
            SocioId = socioId;
            NumeroCarnet = numeroCarnet;
        }

        public Carnet(int socioId, string numeroCarnet, DateTime? fechaVencimiento) : this(socioId, numeroCarnet)
        {
            FechaVencimiento = fechaVencimiento;
        }

        // Método para verificar si el carnet está vencido
        public bool EstaVencido()
        {
            return FechaVencimiento.HasValue && FechaVencimiento.Value < DateTime.Now;
        }

        // Método para calcular días hasta el vencimiento
        public int DiasHastaVencimiento()
        {
            if (!FechaVencimiento.HasValue) return -1;
            return (int)(FechaVencimiento.Value - DateTime.Now).TotalDays;
        }

        public override string ToString()
        {
            return $"Carnet {NumeroCarnet} - Socio ID: {SocioId}";
        }
    }
}