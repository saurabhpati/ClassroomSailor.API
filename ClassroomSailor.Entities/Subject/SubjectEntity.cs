using System;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Entities.Subject
{
    public class SubjectEntity : IBaseEntity
    {
        [Key]
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "Name of the Subject is required.")]
        [StringLength(32, ErrorMessage = "Subject name cannot exceed 32 characters")]
        public String SubjectName { get; set; }

        [Required(ErrorMessage = "Grade of the Subject is required.")]
        public Int16 Grade { get; set; }
    }
}
