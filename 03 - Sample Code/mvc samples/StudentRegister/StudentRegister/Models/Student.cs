// GC

using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Models
{
    // study modes for a student
    public enum StudyModes
    {
        [Display(Name = "Full-Time")]
        FullTime,
        [Display(Name = "Part-Time")]
        PartTime
    };

    // details for a student register
    public class Student
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Study Mode")]
        public StudyModes StudyMode { get; set; }           // <select> with <option>s for enum values on UI

        [Display(Name = "Erasmus")]
        public bool isErasmus { get; set; }                 // checkbox on UI
    }
}