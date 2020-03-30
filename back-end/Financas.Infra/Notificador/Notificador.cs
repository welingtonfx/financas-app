using Financas.Infra.Interface;
using Financas.Infra.Interface.Comum;
using System.Collections.Generic;

namespace Financas.Infra.Comum
{
    public class Notificador : INotificador
    {
        private IList<Mensagem> Mensagens { get; set; }

        public Notificador()
        {
            Mensagens = new List<Mensagem>();
        }

        public void AdicionarMensagem(Mensagem mensagem)
        {
            this.Mensagens.Add(mensagem);
        }

        public void AdicionarMensagens(IEnumerable<Mensagem> mensagens)
        {
            foreach (var mensagem in mensagens)
                Mensagens.Add(mensagem);
        }

        public void AdicionarMensagem(string mensagem, MensagemTipoEnum tipo = MensagemTipoEnum.Erro)
        {
            var novaMensagem = new Mensagem(mensagem, tipo);
            this.Mensagens.Add(novaMensagem);
        }

        public IList<Mensagem> ObterMensagens()
        {
            return this.Mensagens;
        }
    }
}
