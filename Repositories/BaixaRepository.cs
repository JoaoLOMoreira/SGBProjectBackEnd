using SgbProject.Data;
using SgbProject.Models;

namespace SgbProject.Repositories
{
    public class BaixaRepository : GenericRepository<Baixa>
    {
        public BaixaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
