using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.API.Models.User;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers.User
{
    [Route("v1/api/[controller]")]
    public class ClassroomSailorUserController<T> : Controller where T : ClassroomSailorUserApiModel
    {
        private readonly IClassroomSailorUserService<T> _service;

        public ClassroomSailorUserController(IClassroomSailorUserService<T> service)
        {
            this._service = service;
        }

        #region Get

        [Route("{id}")]
        public async Task<IActionResult> GetById(String id)
        {
            T entity = await this._service.GetByIdAsync(id).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> GetByEmail(String email)
        {
            T entity = await this._service.GetByEmailAsync(email).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<T> entity = await this._service.GetAllAsync().ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion

        #region Add

        [HttpPost]
        [Route("Create")]
        public virtual async Task<IActionResult> PostAsync([FromBody]T model)
        {
            if (model == null)
            {
                return new JsonResult(null);
            }

            T entity = await this._service.AddAsync(model).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("Update")]
        public virtual async Task<IActionResult> UpdateAsync([FromBody]T model)
        {
            if (model == null)
            {
                return new JsonResult(null);
            }

            T entity = await this._service.UpdateAsync(model).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(String id)
        {
            T entity = await this._service.DeleteAsync(id).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion
    }
}
