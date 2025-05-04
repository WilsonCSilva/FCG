using FCG.Models;

namespace FCG.Interfaces
{
    public interface IEFRepository<T> where T : EntityBase
    {
        IList<T> ObterTodos();
        T ObterPorID(int id);
        void Cadastrar(T entity);
        void Alterar(T entity);
        void Deletar(int id);
    }
}
