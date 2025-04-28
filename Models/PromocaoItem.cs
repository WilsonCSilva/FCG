namespace FCG.Models
{
    public class PromocaoItem : EntityBase
    {
        public required int GameId { get; set; }
        public required decimal PrecoPromocional { get; set; }
        
        #region [Navegação]

        public virtual Promocao Promocao { get; set; }

        #endregion
    }
}
