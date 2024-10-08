using AutoMapper;
using Realtech.Modelos;
using Realtech.Modelos.DTO;

namespace Realtech.Mapper
{
    public class PerfillMapa : Profile
    {
        public PerfillMapa()
        {
            CreateMap<CategoriaDTO, CategoriaRepositorio>();
            CreateMap<CategoriaRepositorio, CategoriaDTO>();
        }
    }
}
