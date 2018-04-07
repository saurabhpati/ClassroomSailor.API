using System;
using System.ComponentModel.DataAnnotations;

namespace ClassroomSailor.Entities.Subject
{
    public class SubjectEntity
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Subject cannot be more than 32 characters.")]
        public String Name { get; set; }
    }
}
