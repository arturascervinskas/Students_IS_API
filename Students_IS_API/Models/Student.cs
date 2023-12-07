using System.ComponentModel.DataAnnotations;

namespace Students_IS_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int? Department_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
    }
}
