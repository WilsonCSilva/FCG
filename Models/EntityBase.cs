namespace FCG.Models
{
    public class EntityBase
    {
        /// <summary>
        /// Gerado automaticamente pelo banco de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de criação do registro gerada automaticamente. Formato: yyyy-MM-dd
        /// </summary>
        public DateTime DataCriacao { get; set; }

        public string Nome { get; internal set; }

        public EntityBase()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
