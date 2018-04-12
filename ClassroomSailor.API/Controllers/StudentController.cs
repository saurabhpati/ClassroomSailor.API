using ClassroomSailor.API.Controllers.User;
using ClassroomSailor.Entities.Student;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    [Route("v1/api/[controller]")]
    public class StudentController : ClassroomSailorUserController<StudentEntity>
    {
        public StudentController(IClassroomSailorUserService<StudentEntity> service) : base(service)
        {
        }
    }
}
