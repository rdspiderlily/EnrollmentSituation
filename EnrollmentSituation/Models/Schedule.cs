using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSituation.Models
{
    public class Schedule
    {
        [Key]
        public int SchedId { get; set; }


        [Required, StringLength(100)]
        public string SchedSubjName { get; set; }

        [StringLength(10)]
        public string SchedSem { get; set; }

        [StringLength(10)]
        public string SchedCurrSy { get; set; }

        public int SchedSubjUnits { get; set; }

        [StringLength(20)]
        public string SchedHours { get; set; }

        [StringLength(30)]
        public string SchedDays { get; set; }

        public int EnrollId { get; set; }

        public int StudId { get; set; }

        [StringLength(20)]
        public string CourseCode { get; set; }

        public int InstrId { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("EnrollId")]
        public virtual Enrollment Enrollment { get; set; }

        [ForeignKey("StudId")]
        public virtual Student Student { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Course { get; set; }

        [ForeignKey("InstrId")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
