using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSituation.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [StringLength(50)]
        public string RoomHours { get; set; }

        [StringLength(50)]
        public string RoomDays { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<TeachAssignment> TeachAssignments { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
