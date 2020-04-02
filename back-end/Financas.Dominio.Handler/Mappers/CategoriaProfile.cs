using AutoMapper;
using Financas.Dominio.Handler.Commands.Categoria;
using System;

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
