using FCG.Interfaces;
using FCG.Models;

namespace FCG.Infrastructure.Repository
{
    public class GameRepository : EFRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
