using Realtech.Modelos.DTO;

namespace Realtech.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        //para obtener todas las categorias
        public Task<IEnumerable<CategoriaDTO>> GetAllCategorias();
        //para obtener la categoria única
        public Task<CategoriaDTO> GetCategoria(int categoriaId);
        //para crear Categoria
        public Task<CategoriaDTO> CreaCategoria(CategoriaDTO categoriaDTO );
        //Para Actualizar Categoria
        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);
        //Para verificar si categoria existe
        public Task<CategoriaDTO> NombreCategoriaExiste(string nombre);
        // Para Borrar Categoria
        public Task<int> BorrarCategoria(int categoriaId);
        //Para llenar el drop down de las categorias
        public Task<IEnumerable<CategoriaDTO>> GetDropDownCategorias();
         
    }

}
