using System.ComponentModel.DataAnnotations;

namespace BlazorAppAuth.Modelos.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre de la categoria es obligatorio")]
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
