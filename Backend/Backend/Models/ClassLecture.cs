namespace Backend.Models
{
    public class ClassLecture
    {
        public int Id { get; set; } //primary key
        public string Title { get; set; } = "";

        
        public int SubjectId { get; set; } //foreign key to Subject
        public Subject? Subject { get; set; }

        
        public int TeacherId { get; set; }//foreign key to Teacher
        public Teacher? Teacher { get; set; }


        public ICollection<Enrollment>? Enrollments { get; set; }// to represent relationship with Enrollment
    }
}
