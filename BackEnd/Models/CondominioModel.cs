namespace BackEnd.Models
{
    public class CondominioModel
    {
        public int IdCondominio { get; set; }
        public string NombreCondominio { get; set; } = null!;
        public int Vacantes { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public int IdDireccion { get; set; }
        public int? IdAreacomun { get; set; }
    }
}
