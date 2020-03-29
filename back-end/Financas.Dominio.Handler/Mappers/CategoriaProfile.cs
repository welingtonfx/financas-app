using AutoMapper;
using Financas.Dominio.Handler.Commands.Categoria;

namespace Financas.Dominio.Handler.Mappers
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CriarCategoriaCommand, Model.Categoria>();

            CreateMap<AlterarCategoriaCommand, Model.Categoria>();
        }
    }
}
