namespace Backend.Models
{
    public class Subject
    {
        public int Id { get; set; }//primary key
        public string Name { get; set; } = "";


        public ICollection<ClassLecture>? ClassLectures { get; set; }// to represent relationship with class lecture
    }
}
