using AutoMapper;
using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Dominio.Model;
using System;

namespace Financas.Dominio.Handler.Mappers
{
    public class TransacaoProfile : Profile
    {
        public TransacaoProfile()
        {
            CreateMap<CriarTransacaoCommand, Transacao>()
                .ForMember(m => m.DataCriacao, f => f.MapFrom(t => DateTime.Now))
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));

            CreateMap<AlterarTransacaoCommand, Transacao>()
                .ForMember(m => m.DataCriacao, f => f.Ignore())
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now));

            CreateMap<TransacaoDetalheCommand, TransacaoDetalhe>()
                .ForMember(m => m.DataAlteracao, f => f.MapFrom(t => DateTime.Now))
                .AfterMap((src, dest) =>
                {
                    if (dest.DataCriacao == DateTime.MinValue)
                        dest.DataCriacao = DateTime.Now;
                });

            CreateMap<TransacaoDetalhe, TransacaoDetalheCommand>();
        }
    }
}
