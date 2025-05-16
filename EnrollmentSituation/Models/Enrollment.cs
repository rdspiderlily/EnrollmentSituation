using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSituation.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollId { get; set; }

        [Required, StringLength(10)]
        public string EnrollSem { get; set; }

        [Required, StringLength(10)]
        public string EnrollCurrSy { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan EnrollTime { get; set; }

        [StringLength(15)]
        public string EnrollDay { get; set; }

        [StringLength(20)]
        public string CourseCode { get; set; }

        public int StudId { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudId")]
        public virtual Student Student { get; set; }
    }

}
