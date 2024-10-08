using System.ComponentModel.DataAnnotations;

namespace Realtech.Modelos.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        
        public String NombreCategoria { get; set; }
       
        public string Descripcion { get; set; }
    }
}
