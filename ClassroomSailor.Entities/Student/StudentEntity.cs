using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;
using ClassroomSailor.Entities.Subject;

namespace ClassroomSailor.Entities.Student
{
    public class StudentEntity : ClassroomSailorUserEntity
    {
        [Required(ErrorMessage = "The admission number is required")]
        [StringLength(16, ErrorMessage = "Admission number cannot be more than 16 characters")]
        public String AdmissionNumber { get; set; }

        [Required(ErrorMessage = "Date of admission is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date of admission")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public Int16 Grade { get; set; }

        public IList<SubjectEntity> Subjects { get; set; }
    }
}
