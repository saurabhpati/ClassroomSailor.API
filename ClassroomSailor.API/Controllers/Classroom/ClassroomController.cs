using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.API.Models.Classroom;
using ClassroomSailor.Services.Classroom;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers.Classroom
{
    [Route("v1/api/[controller]")]
    public class ClassroomController
    {
        private readonly IClassroomService<ClassroomApiModel> _service;

        public ClassroomController(IClassroomService<ClassroomApiModel> service)
        {
            this._service = service;
        }

        [Route("{id}")]
        public async Task<IActionResult> Get(Int32 id)
        {
            ClassroomApiModel model = await this._service.GetByIdAsync(id).ConfigureAwait(false);
            return new JsonResult(model);
        }

        [Route("{grade}")]
        public async Task<IActionResult> Get(Int16 grade)
        {
            IEnumerable<ClassroomApiModel> rooms = await this._service.GetClassroomsByGrade(grade).ConfigureAwait(false);
            return new JsonResult(rooms);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<ClassroomApiModel> models = await this._service.GetAllAsync().ConfigureAwait(false);
            return new JsonResult(models);
        }

        [Route("Create")]
        public async Task<IActionResult> Post([FromBody]ClassroomApiModel model)
        {
            ClassroomApiModel output = await this._service.AddAsync(model).ConfigureAwait(false);
            return new JsonResult(output);
        }
    }
}
