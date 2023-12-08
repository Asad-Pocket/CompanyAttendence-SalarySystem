using GTRTraining.Data;
using GTRTraining.Models;

namespace GTRTraining.Repositories
{
    public class CompanyRepository : Repository<Company> , ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}
