namespace BackEnd.Models
{
    public class DepartamentoModel
    {
        public int IdDepartamento { get; set; }
        public int CantidadCuartos { get; set; }
        public int CantidadBanios { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public int IdCondominio { get; set; }
    }
}
