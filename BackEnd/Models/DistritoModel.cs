namespace BackEnd.Models
{
    public class DistritoModel
    {
        public int IdDistrito { get; set; }
        public string NombreDistrito { get; set; } = null!;
        public int IdCanton { get; set; }
    }
}
