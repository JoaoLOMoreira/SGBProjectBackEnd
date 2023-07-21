using Microsoft.EntityFrameworkCore;
using SgbProject.Data;
using SgbProject.Enums;
using SgbProject.Models;

namespace SgbProject.Repositories
{
    public class BovinosRepository : GenericRepository<Bovino>
    {
        public BovinosRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
