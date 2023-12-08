using GTRTraining.Data;
using GTRTraining.DtoModel;
using GTRTraining.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GTRTraining.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext ctx) : base(ctx)
        {
            
        }

        public IEnumerable<EmployeeViewModel> GetAllInItem(int ComId)
        {
            var employeeDetails = _ctx.Employees
                .Where(e => e.ComId == ComId)
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Shift)
                .AsEnumerable()  // Switch to client-side processing
                .Select(e => new EmployeeViewModel
                {
                    EmpId = e.EmpId,
                    EmpCode = e.EmpCode,
                    EmpName = e.EmpName,
                    DeptName = e.Department.DeptName,
                    DesigName = e.Designation.DesigName,
                    ShiftName = e.Shift.ShiftName,
                    ShiftLateTime = null,
                    Gender = e.Gender,
                    Gross = e.Gross,
                    Basic = e.Basic,
                    HRent = e.HRent,
                    Medical = e.Medical,
                    Others = e.Others,
                    DtJoin = e.DtJoin,
                    ComId = e.ComId  // Add the ComId property if needed
                })
                .ToList();

            return employeeDetails;
        }

        public IEnumerable<EmployeeViewModel> GetAllByDept(int ComId, int DeptId)
        {
            var employeeDetails = _ctx.Employees
                .Where(e => e.ComId == ComId && e.DeptId == DeptId)
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Shift)
                .AsEnumerable()  // Switch to client-side processing
                .Select(e => new EmployeeViewModel
                {
                    EmpId = e.EmpId,
                    EmpCode = e.EmpCode,
                    EmpName = e.EmpName,
                    DeptName = e.Department.DeptName,
                    DesigName = e.Designation.DesigName,
                    ShiftName = e.Shift.ShiftName,
                    ShiftLateTime = null,
                    Gender = e.Gender,
                    Gross = e.Gross,
                    Basic = e.Basic,
                    HRent = e.HRent,
                    Medical = e.Medical,
                    Others = e.Others,
                    DtJoin = e.DtJoin,
                    ComId = e.ComId,
                    DeptId = e.DeptId// Add the ComId property if needed
                })
                .ToList();

            return employeeDetails;
        }

        public EmployeeViewModel Get(int id)
        {
            var employeeDetails = _ctx.Employees
               .Where(e => e.EmpId == id)
               .Include(e => e.Department)
               .Include(e => e.Designation)
               .Include(e => e.Shift)
               .Select(e => new EmployeeViewModel
               {
                   EmpId = e.EmpId,
                   EmpCode = e.EmpCode,
                   EmpName = e.EmpName,
                   DeptName = e.Department.DeptName,
                   DesigName = e.Designation.DesigName,
                   ShiftName = e.Shift.ShiftName,
                   ShiftLateTime = e.Shift.ShiftLateTime,
                   Gender = e.Gender,
                   Gross = e.Gross,
                   Basic = e.Basic,
                   HRent = e.HRent,
                   Medical = e.Medical,
                   Others = e.Others,
                   DtJoin = e.DtJoin,
                   ComId = e.ComId  // Add the ComId property if needed
               }).FirstOrDefault(); ;
            return employeeDetails;
        }

 
    }
}
