namespace FCG.Models
{
    public class PedidoItem : EntityBase
    {
        public required int PedidoId { get; set; }
        public required int GameId { get; set; }
        public required int QuantidadePedido { get; set; }

        #region [Navegação]

        public virtual Pedido Pedido { get; set; }

        #endregion
    }
}
