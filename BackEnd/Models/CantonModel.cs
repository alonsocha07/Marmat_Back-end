namespace BackEnd.Models
{
    public class CantonModel
    {
        public int IdCanton { get; set; }
        public string NombreCanton { get; set; } = null!;
        public int IdProvincia { get; set; }
    }
}
