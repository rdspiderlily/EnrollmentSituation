using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSituation.Models
{
    public class TeachAssignment
    {
        public int InstrId { get; set; }

        [StringLength(20)]
        public string CourseCode { get; set; }

        public int RoomId { get; set; }

        [StringLength(20)]
        public string TaRoomTime { get; set; }

        [StringLength(20)]
        public string TaRoomDay { get; set; }

        [ForeignKey("InstrId")]
        public virtual Instructor Instructors { get; set; }

        [ForeignKey("CourseCode")]
        public virtual Course Courses { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
