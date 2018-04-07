using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Teacher;

namespace ClassroomSailor.Services.Teacher
{
    public interface ITeacherService
    {
        Task<TeacherEntity> GetTeacherById(Int64 teacherId);

        Task<TeacherEntity> GetTeacherByEmail(String email);

        Task<IEnumerable<TeacherEntity>> GetAllTeachers();
    }
}
