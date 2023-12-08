using GTRTraining.DtoModel;
using GTRTraining.Models;

namespace GTRTraining.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IEnumerable<EmployeeViewModel> GetAllInItem(int id);
        public IEnumerable<EmployeeViewModel> GetAllByDept(int Cid, int id);
        public EmployeeViewModel Get(int id);
    }
}
