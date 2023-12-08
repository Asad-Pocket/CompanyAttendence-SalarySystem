
using GTRTraining.Models;

namespace GTRTraining.DtoModel
{
    public class SearchViewItem 
    {
        public List<Department> Departments { get; set; }
       
        public int SelectedDepartment { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
