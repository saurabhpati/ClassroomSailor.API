using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Student;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    public class StudentController : Controller
    {
        private readonly IClassroomSailorUserService<StudentEntity> _service;

        public StudentController(IClassroomSailorUserService<StudentEntity> service)
        {
            this._service = service;
        }

        #region Get

        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            StudentEntity entity = await this._service.GetByIdAsync(id);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            StudentEntity entity = await this._service.GetByEmailAsync(email);
            return new JsonResult(entity);
        }

        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<StudentEntity> entity = await this._service.GetAllAsync();
            return new JsonResult(entity);
        }

        #endregion

        #region Add

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]StudentEntity teacher)
        {
            if (teacher == null)
            {
                return null;
            }

            StudentEntity entity = await this._service.AddAsync(teacher);
            return new JsonResult(entity);
        }

        #endregion
    }
}
