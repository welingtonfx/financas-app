namespace Financas.Infra.Interface
{
    public class Mensagem
    {
        public Mensagem(string mensagem, MensagemTipoEnum tipo = MensagemTipoEnum.Erro)
        {
            this.Descricao = mensagem;
            this.MensagemTipo = tipo;
        }

        public MensagemTipoEnum MensagemTipo { get; set; }
        public string Descricao { get; set; }
    }
}
