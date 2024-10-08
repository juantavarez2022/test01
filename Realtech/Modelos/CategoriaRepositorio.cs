using System.ComponentModel.DataAnnotations;

namespace Realtech.Modelos
{
    public class CategoriaRepositorio 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String NombreCategoria  { get; set; }
        public  string Descripcion { get; set; }
        public DateTime Fechacreacion   { get; set; }=DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

       // public virtual ICollection<Propiedad> Propiedad { get; set; }

    }
}
