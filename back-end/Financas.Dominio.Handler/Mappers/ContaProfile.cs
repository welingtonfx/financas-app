using AutoMapper;
using Financas.Dominio.Handler.Commands.Conta;

namespace Financas.Dominio.Handler.Mappers
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<CriarContaCommand, Model.Conta>();

            CreateMap<AlterarContaCommand, Model.Conta>();
        }
    }
}
