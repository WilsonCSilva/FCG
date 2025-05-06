using FCG.Interfaces;
using FCG.Models;

namespace FCG.Infrastructure.Repository
{
    public class PromocaoRepository : EFRepository<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
