namespace FCG.Models
{
    public class Game : EntityBase
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required decimal Preco { get; set; }
        public required DateTime DataLancamento { get; set; }
    }
}
