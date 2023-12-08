using GTRTraining.Data;
using GTRTraining.Models;

namespace GTRTraining.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}
