using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;
using ClassroomSailor.Entities.Subject;

namespace ClassroomSailor.Entities.Teacher
{
    public class TeacherEntity : ClassroomSailorUserEntity
    {
        [Required(ErrorMessage = "Date of joining is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date of joining")]
        public DateTime JoiningDate { get; set; }

        public IList<SubjectEntity> Subjects { get; set; }
    }
}
