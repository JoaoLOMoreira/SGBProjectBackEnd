using SgbProject.Data;
using SgbProject.Models;

namespace SgbProject.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuario>
    {
        public UsuariosRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
