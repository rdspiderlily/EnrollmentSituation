using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSituation.Models
{
    public class Instructor
    {
        [Key]
        public int InstrId { get; set; }

        [Required, StringLength(100)]
        public string InstrName { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public virtual ICollection<TeachAssignment> TeachAssignments { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
