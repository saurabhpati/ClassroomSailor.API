using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Services.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    [Route("v1/api/Teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Get(Int64 id)
        {
            TeacherEntity entity = await this._service.GetTeacherById(id);

            return new JsonResult(entity);
        }
    }
}
