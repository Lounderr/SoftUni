using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Unicode]
        [MaxLength(80)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Precision(12, 2)]
        public double Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Homework> Homework { get; set; }
    }
}
