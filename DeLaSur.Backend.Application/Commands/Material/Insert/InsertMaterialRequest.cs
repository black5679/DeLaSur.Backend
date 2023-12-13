using Microsoft.AspNetCore.Http;

namespace DeLaSur.Backend.Application.Commands.Material.Insert
{
    public class InsertMaterialRequest
    {
        public required int IdTipoMaterial { get; set; }
        public required int IdCategoriaMaterial { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required int UsuarioCreacion { get; set; }
        public List<IFormFile> Modelos { get; set; } = new List<IFormFile>();
        public List<int> Colores { get; set; } = new List<int>();
        public required List<InsertEspacioRequest> Espacios { get; set; }
    }
    public class InsertEspacioRequest
    {
        public int IdForma { get; set; }
    }
}
