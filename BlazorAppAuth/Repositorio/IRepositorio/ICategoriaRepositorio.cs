using BlazorAppAuth.Modelos.DTO;

namespace BlazorAppAuth.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        public Task<IEnumerable<CategoriaDTO>> GetAllCategorias();

        public Task<CategoriaDTO> GetCategoria(int categoriaId);

        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);

        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);

        public Task<CategoriaDTO> NombreCategoriaExiste(string nombreCategoria);

        public Task<CategoriaDTO> BorrarCategoria(int categoriaId);
    }
}
