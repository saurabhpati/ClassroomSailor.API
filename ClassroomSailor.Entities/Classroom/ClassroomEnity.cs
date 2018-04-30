using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClassroomSailor.Entities.Common;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Classroom
{
    public class ClassroomEnity : IBaseEntity
    {
        [Key]
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        public Int16 Grade { get; set; }

        [Required(ErrorMessage = "Section Name is required.")]
        [StringLength(16, ErrorMessage = "Name of the section cannot exceed 16 characters.")]
        public String Section { get; set; }

        public IEnumerable<SubjectEntity> Subjects { get; set; }

        public IEnumerable<ClassroomSailorUserEntity> Users { get; set; }
    }
}
