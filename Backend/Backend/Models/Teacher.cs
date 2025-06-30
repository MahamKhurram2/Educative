namespace Backend.Models
{
    public class Teacher
    {
        public int Id { get; set; } //primary key
        public string Name { get; set; } = ""; // to avoid nullabe referenece warnings

        public ICollection<ClassLecture>? ClassLectures { get; set; } // to represent reltionship with ClassLecture altough it was not necessary 

    }
}
