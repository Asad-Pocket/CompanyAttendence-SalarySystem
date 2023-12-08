using GTRTraining.Data;
using GTRTraining.DtoModel;
using GTRTraining.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Entity;

namespace GTRTraining.Repositories
{
    public class EmployeeAttendenceRepository : Repository<EmployeeAttendance>, IEmployeeAttendenceRepository
    {
        public EmployeeAttendenceRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }


    }
}