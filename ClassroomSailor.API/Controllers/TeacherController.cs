using ClassroomSailor.API.Controllers.User;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    [Route("v1/api/[controller]")]
    public class TeacherController : ClassroomSailorUserController<TeacherEntity>
    {
        public TeacherController(IClassroomSailorUserService<TeacherEntity> service) : base(service)
        {
        }
    }
}
