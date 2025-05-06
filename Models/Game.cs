namespace FCG.Models
{
    public class Game : EntityBase
    {
        /// <summary>
        /// Nome do jogo. Máximo 200 caracteres.
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>
        /// Descrição do jogo. Máximo 500 caracteres.
        /// </summary>
        public required string Descricao { get; set; }

        /// <summary>
        /// Preço do jogo. Formato: 0.00
        /// </summary>
        public required decimal Preco { get; set; }

        /// <summary>
        /// Data de lançamento do jogo. Formato: yyyy-MM-dd
        /// </summary>
        public required DateTime DataLancamento { get; set; }
    }
}
