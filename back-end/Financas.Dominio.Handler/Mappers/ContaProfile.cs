using AutoMapper;
using Financas.Dominio.Handler.Commands.Conta;
using System;

namespace Financas.Dominio.Handler.Mappers
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<CriarContaCommand, Model.Conta>()
                .ForMember(m => m.DataCriacao, f => f.MapFrom(t => DateTime.Now))
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));

            CreateMap<AlterarContaCommand, Model.Conta>()
                .ForMember(m => m.DataCriacao, f => f.Ignore())
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));
        }
    }
}
