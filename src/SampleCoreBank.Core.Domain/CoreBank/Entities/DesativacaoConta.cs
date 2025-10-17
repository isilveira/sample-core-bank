using System.Text.Json.Serialization;

namespace SampleCoreBank.Core.Domain.CoreBank.Entities
{
    public class DesativacaoConta
    {
        public string DocumentoTitular { get; set; }
        public DateTime Data { get; set; }
        public string Responsavel { get; set; }
		[JsonIgnore]
		public virtual Conta Conta { get; set; }
    }
}