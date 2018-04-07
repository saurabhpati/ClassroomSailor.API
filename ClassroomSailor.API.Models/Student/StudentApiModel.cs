using System;
using ClassroomSailor.Entities.Student;

namespace ClassroomSailor.API.Models.Student
{
    public class StudentApiModel : StudentEntity
    {
        public String Url { get; set; }
    }
}
