using System;
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

        #region Get

        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Int64 id)
        {
            TeacherEntity entity = await this._service.GetByIdAsync(id);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> GetAsync(String email)
        {
            TeacherEntity entity = await this._service.GetByEmailAsync(email);
            return new JsonResult(entity);
        }

        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<TeacherEntity> entity = await this._service.GetAllAsync();
            return new JsonResult(entity);
        }

        #endregion

        #region Add

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> PostAsync([FromBody]TeacherEntity teacher)
        {
            if (teacher == null)
            {
                return null;
            }

            TeacherEntity entity = await this._service.AddAsync(teacher);
            return new JsonResult(entity);
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]TeacherEntity teacher)
        {
            if (teacher == null)
            {
                return null;
            }

            TeacherEntity entity = await this._service.UpdateAsync(teacher);
            return new JsonResult(entity);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            if (id < 0)
            {
                return null;
            }

            TeacherEntity entity = await this._service.DeleteAsync(id);
            return new JsonResult(entity);
        }

        #endregion
    }
}
