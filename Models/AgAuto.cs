namespace AGDeberPrograP2.Models
{
    public class AgAuto
    {
        public int Id { get; set; } // Identificador único del auto
        public string Marca { get; set; } // Marca del auto (por ejemplo: Toyota, Ford, etc.)
        public string Modelo { get; set; } // Modelo del auto (por ejemplo: Corolla, Mustang, etc.)
        public int AñoFabricacion { get; set; } // Año de fabricación del auto
        public double Precio { get; set; } // Precio del auto en dólares

        public AgAuto()
        {
           
        }

        // Otros métodos y lógica relacionada con la clase Auto
    }
}