namespace FCG.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; internal set; }

        public EntityBase()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
