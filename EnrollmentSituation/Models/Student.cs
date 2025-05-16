using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace EnrollmentSituation.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }

        [Required]
        public int StudIDNumber { get; set; }

        [Display(Name = "First Name")]
        [Required, StringLength(50)]
        public string StudFName { get; set; }

        [Display(Name = "Last Name")]
        [Required, StringLength(50)]
        public string StudLName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50)]
        public string StudMName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime StudDob { get; set; }

        [Display(Name = "Current Address")]
        [StringLength(100)]
        public string StudCurrAddress { get; set; }

        [Display(Name = "District")]
        [StringLength(100)]
        public string StudConDstrct { get; set; }

        [Display(Name = "City Address")]
        [StringLength(100)]
        public string StudCityAddress { get; set; }

        [Display(Name = "Contact Number")]
        [Phone, StringLength(20)]
        public string StudContact { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress, StringLength(100)]
        public string StudEmail { get; set; }

        [Display(Name = "Are you the First Generation Student starting a degree?")]
        public bool StudIsFirstGen { get; set; }

        [Display(Name = "Year Level")]
        [StringLength(10)]
        public string StudYrLvl { get; set; }

        [Display(Name = "Course/Program")]
        [StringLength(10)]
        public string StudCurrSy { get; set; }

        [Display(Name = "Semester")]
        [StringLength(10)]
        public string StudCurrSem { get; set; }

        [Display(Name = "Status")]
        [StringLength(20)]
        public string StudStatus { get; set; }

        public int ProgId { get; set; }

        [ForeignKey("ProgId")]
        public virtual Program Program { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
