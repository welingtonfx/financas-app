using System.Collections.Generic;

namespace Financas.Infra.Interface.Comum
{
    public interface INotificador
    {
        void AdicionarMensagem(Mensagem mensagem);

        void AdicionarMensagens(IEnumerable<Mensagem> mensagens);

        void AdicionarMensagem(string mensagem, MensagemTipoEnum tipo = MensagemTipoEnum.Erro);
        IList<Mensagem> ObterMensagens();
    }
}
