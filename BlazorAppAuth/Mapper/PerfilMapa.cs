using AutoMapper;
using BlazorAppAuth.Modelos;
using BlazorAppAuth.Modelos.DTO;

namespace BlazorAppAuth.Mapper
{
    public class PerfilMapa : Profile
    {
        public PerfilMapa()
        {
            CreateMap<CategoriaDTO, Categoria> ();
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
