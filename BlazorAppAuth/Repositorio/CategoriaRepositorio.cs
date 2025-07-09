using AutoMapper;
using BlazorAppAuth.Data;
using BlazorAppAuth.Modelos;
using BlazorAppAuth.Modelos.DTO;
using BlazorAppAuth.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppAuth.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public CategoriaRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            _bd = bd;
            _mapper = mapper;
        }
        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaId == categoriaDTO.Id)
                {
                    Categoria categoria = await _bd.Categoria.FindAsync(categoriaId);
                    Categoria cate = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaActualizada = _bd.Categoria.Update(cate);
                    await _bd.SaveChangesAsync();
                    return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> BorrarCategoria(int categoriaId)
        {
            var categoria = await _bd.Categoria.FindAsync(categoriaId);
            if (categoria != null)
            {
                _bd.Categoria.Remove(categoria);
                await _bd.SaveChangesAsync();
                return _mapper.Map<Categoria, CategoriaDTO>(categoria);
            }
            return null;
        }

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            var categoriaAgregada = _bd.Categoria.AddAsync(categoria);
            await _bd.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoriaAgregada.Result.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriasDTO = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_bd.Categoria);
                return (categoriasDTO);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(await _bd.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return categoriaDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoriaDTO> NombreCategoriaExiste(string nombre)
        {
            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<Categoria, CategoriaDTO>(await _bd.Categoria.FirstOrDefaultAsync(c => c.NombreCategoria.ToLower().Trim() == nombre.ToLower().Trim()));
            return categoriaDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }
    }
}
