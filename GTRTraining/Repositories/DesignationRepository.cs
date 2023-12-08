using GTRTraining.Data;
using GTRTraining.Models;

namespace GTRTraining.Repositories
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository( ApplicationDbContext ctx) : base(ctx)
        {
            
        }
    }
}
