using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [Index(nameof(StudentId), nameof(ClassLectureId), IsUnique = true)] // fro avoiding duplicate enrollments
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ClassLectureId { get; set; }
        public ClassLecture? ClassLecture { get; set; }
    }
}
