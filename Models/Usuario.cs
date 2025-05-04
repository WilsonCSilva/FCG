namespace FCG.Models
{
    public class Usuario : EntityBase
    {
        /// <summary>
        /// Nome completo do usuário. Máx. 200 caracteres.
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>Máx. 100 caracteres.</summary>
        public required string Email { get; set; }

        /// <summary>
        /// Máx. 50 caracteres.
        /// </summary>
        public required string Senha { get; set; }

        /// <summary>
        /// Formato: dd/MM/yyyy.
        /// </summary>
        public required DateTime DataNascimento { get; set; }
    }
}
