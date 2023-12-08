using GTRTraining.Data;
using GTRTraining.Models;

namespace GTRTraining.Repositories
{
    public class ShiftRepository : Repository<Shift>,IShiftRepository
    {
        public ShiftRepository(ApplicationDbContext ctx) : base(ctx)
        {
            
        }
    }
}
