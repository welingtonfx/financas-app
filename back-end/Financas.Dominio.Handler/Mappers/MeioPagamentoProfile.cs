using AutoMapper;
using Financas.Dominio.Handler.Commands.MeioPagamento;
using Financas.Dominio.Model;
using System;

namespace Financas.Dominio.Handler.Mappers
{
    public class MeioPagamentoProfile : Profile
    {
        public MeioPagamentoProfile()
        {
            CreateMap<CriarMeioPagamentoCommand, MeioPagamento>()
                .ForMember(m => m.DataCriacao, f => f.MapFrom(t => DateTime.Now))
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));

            CreateMap<AlterarMeioPagamentoCommand, MeioPagamento>()
                .ForMember(m => m.DataCriacao, f => f.Ignore())
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));
        }
    }
}
