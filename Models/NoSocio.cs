namespace ClubDeportivoSystem.Models
{
    public class NoSocio
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int ActividadesRealizadas { get; set; }

        // Propiedades de navegación
        public Persona Persona { get; set; }

        public NoSocio()
        {
            ActividadesRealizadas = 0;
        }
    }
}
