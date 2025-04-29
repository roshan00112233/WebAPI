using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAPI.Models
{
    public class EmployeeRequest
    {
        public List<Employee> EmployeeColl { get; set; } = new List<Employee>();
    }
    [Table("tbl_Employee")]
    public class Employee
    {
        
        public int AutoNumber { get; set; }  
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string FirstName { get; set; }      
        public int? Gender { get; set; }

        [MaxLength(100)]
        public string Religion { get; set; }   
        
        [MaxLength(15)]
        public string? PersnalContactNo { get; set; }

        [MaxLength(30)]
        public string EmailId { get; set; }         
        public int? CreateBy { get; set; }         

    }
   
}
