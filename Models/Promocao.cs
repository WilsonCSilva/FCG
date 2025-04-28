namespace FCG.Models
{
    public class Promocao : EntityBase
    {
        public required DateTime DataInicioPromocao { get; set; }
        public required DateTime DataFimPromocao { get; set; }

        #region [Navegação]

        public virtual IEnumerable<PromocaoItem> Itens { get; set; }

        #endregion
    }
}
