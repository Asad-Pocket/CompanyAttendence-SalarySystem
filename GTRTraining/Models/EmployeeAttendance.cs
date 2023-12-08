using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GTRTraining.Models;
public class EmployeeAttendance
{
    [Key]
    [Column(Order = 0)]
    public int ComId { get; set; }

    [Key]
    [Column(Order = 1)]
    public int EmpId { get; set; }

    [Key]
    [Column(Order = 2, TypeName = "date")]
    public DateTime dtDate { get; set; }

    public string AttStatus { get; set; }  // stutus can present,late, absent 

    public TimeSpan? InTime { get; set; }  

    public TimeSpan? OutTime { get; set; }
}
