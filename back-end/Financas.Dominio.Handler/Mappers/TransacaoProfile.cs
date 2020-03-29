using AutoMapper;
using Financas.Dominio.Handler.Commands.Transacao;

namespace Financas.Dominio.Handler.Mappers
{
    public class TransacaoProfile : Profile
    {
        public TransacaoProfile()
        {
            CreateMap<CriarTransacaoCommand, Model.Transacao>();

            CreateMap<AlterarTransacaoCommand, Model.Transacao>();
        }
    }
}
