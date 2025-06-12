using System;

namespace ClubDeportivoSystem.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool AptoFisico { get; set; }
        public string TipoPersona { get; set; }

        public Persona()
        {
            FechaRegistro = DateTime.Now;
        }

        public Persona(string nombre, string apellido, string dni, string tipo, bool aptoFisico)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            TipoPersona = tipo;
            AptoFisico = false;
            FechaRegistro = DateTime.Now;
           
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}