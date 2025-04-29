using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAPI.Models
{
    [Table("tbl_Student")]

    public class Student
    {
        public int? StudentId { get; set; }
        public string Name { get; set; } = " ";
        public int? gender { get; set; }
        public string Religion { get; set; } = " ";
        public string PersonalContactNo { get; set; } = " ";
        public string Email { get; set; } = " ";
    }
}
