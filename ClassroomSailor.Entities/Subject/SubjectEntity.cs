using System;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Entities.Subject
{
    public class SubjectEntity : IBaseEntity
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Subject cannot be more than 32 characters.")]
        public String Name { get; set; }
    }
}
