using System.Text.Json.Serialization;

namespace SampleCoreBank.Core.Domain.CoreBank.Entities
{
    public class Conta
    {
        public string NomeTitular { get; set; }
        public string DocumentoTitular { get; set; }
        public decimal Saldo{ get; set; }
        public DateTime DataAbertura { get; set; }
        public string Status { get { return DesativacaoConta != null && DesativacaoConta.Data > DateTime.MinValue ? "Inativa" : "Ativa"; } }
        public virtual DesativacaoConta DesativacaoConta { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movimentacao> MovimentacoesCreditadas { get; set; }
		[JsonIgnore]
		public virtual ICollection<Movimentacao> MovimentacoesDebitadas { get; set; }
    }
}