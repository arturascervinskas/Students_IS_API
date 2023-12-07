namespace Students_IS_API.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int? Department_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
