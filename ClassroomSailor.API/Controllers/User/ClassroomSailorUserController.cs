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
        public ClassroomSailorUserController(IClassroomSailorUserService<T> service)
        {
            this.Service = service;
        }

        protected IClassroomSailorUserService<T> Service { get; private set; }

        #region Get

        [Route("{id:int}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            T entity = await this.Service.GetByIdAsync(id).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> Get(String email)
        {
            T entity = await this.Service.GetByEmailAsync(email).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<T> entity = await this.Service.GetAllAsync().ConfigureAwait(false);
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

            T entity = await this.Service.AddAsync(model).ConfigureAwait(false);
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

            T entity = await this.Service.UpdateAsync(model).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Int64 id)
        {
            if (id < 0)
            {
                return null;
            }

            T entity = await this.Service.DeleteAsync(id).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        #endregion
    }
}
