using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    [Route("v1/api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly IClassroomSailorUserService<TeacherEntity> _service;

        public TeacherController(IClassroomSailorUserService<TeacherEntity> service)
        {
            this._service = service;
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TeacherEntity entity = await this._service.GetById(id);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            TeacherEntity entity = await this._service.GetByEmail(email);
            return new JsonResult(entity);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<TeacherEntity> entity = await this._service.GetAll();
            return new JsonResult(entity);
        }
    }
}
