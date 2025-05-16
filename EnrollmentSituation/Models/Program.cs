using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSituation.Models
{
    public class Program
    {
        [Key]
        public int ProgId { get; set; }

        [Required, StringLength(100)]
        public string ProgName { get; set; }

        [StringLength(10)]
        public string ProgYear { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

}
