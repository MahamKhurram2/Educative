namespace Backend.Models
{
    public class Student
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; }=""; // to avoid nullable reference warnings


        public ICollection<Enrollment>? Enrollments { get; set; }// to represent relationship with Enrollment
    }
}
