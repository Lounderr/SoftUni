using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new List<Homework>();
            this.CourseEnrollments = new List<StudentCourse>();
        }

        public int StudentId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}
