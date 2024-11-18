namespace lampen.Models
{
    public class Lamp
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public bool Actief { get; set; }
        public string Datum { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Kleur { get; set; } = string.Empty;
        // Relaties 
        public int FabrikantId { get; set; }
        public List<int> StijlIds { get; set; } = new();
    }

}
