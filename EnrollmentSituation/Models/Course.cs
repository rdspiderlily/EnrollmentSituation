using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSituation.Models
{
    public class Course
    {
        [Key, StringLength(20)]
        public string CourseCode { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; }

        public int CourseUnits { get; set; }
        public int CourseLecHours { get; set; }
        public int CourseLabHours { get; set; }
        public int CourseTotHours { get; set; }

        [StringLength(10)]
        public string CourseSem { get; set; }

        [StringLength(10)]
        public string CourseYrLvl { get; set; }

        public int ProgId { get; set; }

        [ForeignKey("ProgId")]
        public virtual Program Program { get; set; }
    }
}
