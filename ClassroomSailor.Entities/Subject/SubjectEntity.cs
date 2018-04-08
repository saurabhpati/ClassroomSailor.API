using System;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Entities.Subject
{
    public class SubjectEntity : BaseEntity
    {
        [Required]
        [StringLength(64, ErrorMessage = "Subject cannot be more than 32 characters.")]
        public String Name { get; set; }
    }
}
