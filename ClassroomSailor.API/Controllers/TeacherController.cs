using ClassroomSailor.API.Controllers.User;
using ClassroomSailor.API.Models.User;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    [Route("v1/api/[controller]")]
    public class TeacherController : ClassroomSailorUserController<TeacherApiModel>
    {
        public TeacherController(IClassroomSailorUserService<TeacherApiModel> service) : base(service)
        {
        }
    }
}
