using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtech.Data;
using Realtech.Data.Migrations;
using Realtech.Modelos;
using Realtech.Modelos.DTO;
using Realtech.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Realtech.Repositorio
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
                    //Valido se puede actulizar record found
                    Modelos.CategoriaRepositorio categoria = await _bd.Categoria.FindAsync(categoriaId);
                    Modelos.CategoriaRepositorio cate = _mapper.Map<CategoriaDTO, Modelos.CategoriaRepositorio>(categoriaDTO, categoria);
                    cate.FechaActualizacion = DateTime.Now;
                    var categoriaactuslizada = _bd.Categoria.Update(cate);
                    await _bd.SaveChangesAsync();
                    return _mapper.Map<Modelos.CategoriaRepositorio, CategoriaDTO>(categoriaactuslizada.Entity);
                }
                else
                {
                    //Invalido
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await _bd.Categoria.FindAsync(categoriaId);
            if (categoria != null)
            {
                _bd.Categoria.Remove(categoria);
                return await _bd.SaveChangesAsync();

            }
            return 0;

        }

        public async Task<CategoriaDTO> CreaCategoria(CategoriaDTO categoriaDTO)
        {
            Modelos.CategoriaRepositorio categoria = _mapper.Map<CategoriaDTO, Modelos.CategoriaRepositorio>(categoriaDTO);
            categoria.Fechacreacion = DateTime.Now;
            var categoriaagregada = await _bd.Categoria.AddAsync(categoria);
            await _bd.SaveChangesAsync();
            return _mapper.Map<Modelos.CategoriaRepositorio, CategoriaDTO>(categoriaagregada.Entity);


        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriaDTO =
                   _mapper.Map<IEnumerable<Modelos.CategoriaRepositorio>, IEnumerable<CategoriaDTO>>(_bd.Categoria);
                return categoriaDTO;

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
                CategoriaDTO categoriaDTO =
                    _mapper.Map<Modelos.CategoriaRepositorio, CategoriaDTO>(await _bd.Categoria.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return (categoriaDTO);
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        public Task<IEnumerable<CategoriaDTO>> GetDropDownCategorias()
        {
            throw new NotImplementedException();
        }                    

        public async Task<CategoriaDTO> NombreCategoriaExiste(string nombre)
        {
            try                                                                           
            {
                CategoriaDTO categoriaDTO =
                           _mapper.Map<Modelos.CategoriaRepositorio, CategoriaDTO>
                           (await _bd.Categoria.FirstOrDefaultAsync(
                               c => c.NombreCategoria.ToLower() == nombre.ToLower()));
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}