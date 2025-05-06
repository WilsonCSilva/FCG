namespace FCG.Models
{
    public class Usuario : EntityBase
    {
        /// <summary>
        /// Nome completo do usuário. Máximo 200 caracteres.
        /// </summary>
        public required string Nome { get; set; }

        /// <summary>Máximo 100 caracteres.</summary>
        public required string Email { get; set; }

        /// <summary>
        /// Máximo 50 caracteres. Obrigatório letras maiúsculas, minúsculas, números e caracteres especiais.
        /// </summary>
        public required string Senha { get; set; }

        /// <summary>
        /// Formato: yyyy-MM-dd
        /// </summary>
        public required DateTime DataNascimento { get; set; }

        /// <summary>
        /// Tipo de usuário: 1 = Administrador, 2 = Usuário comum.
        /// </summary>
        public required short TipoUsuario { get; set; }
    }
}
