namespace FCG.Models
{
    public class Pedido : EntityBase
    {
        public required int UsuarioId { get; set; }
        
        #region [Navegação}

        public virtual IEnumerable<PedidoItem> Itens { get; set; }

        #endregion
    }
}
