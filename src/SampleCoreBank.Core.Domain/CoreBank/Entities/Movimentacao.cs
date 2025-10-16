namespace SampleCoreBank.Core.Domain.CoreBank.Entities
{
    public class Movimentacao
    {
        public string DocumentoTitularDebitado { get; set; }
        public string DocumentoTitularCreditado { get; set; }
        public decimal Valor{ get; set; }
        public DateTime DataOperacao { get; set; }
        public virtual Conta ContaDebitada { get; set; }
        public virtual Conta ContaCreditada { get; set; }
    }
}