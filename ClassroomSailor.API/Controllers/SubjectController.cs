using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.API.Models.Subject;
using ClassroomSailor.Services.Common;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers
{
    public class SubjectController
    {
        private readonly IService<SubjectApiModel> _service;

        public SubjectController(IService<SubjectApiModel> service)
        {
            this._service = service;
        }

        #region Get

        [Route("{id:int}")]
        public async Task<IActionResult> Get(Int64 id)
        {
            SubjectApiModel model = await this._service.GetByIdAsync(id).ConfigureAwait(false);
            return new JsonResult(model);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<SubjectApiModel> model = await this._service.GetAllAsync().ConfigureAwait(false);
            return new JsonResult(model);
        }

        #endregion

        #region Add

        [HttpPost]
        [Route("Create")]
        public virtual async Task<IActionResult> PostAsync([FromBody]SubjectApiModel subject)
        {
            if (subject == null)
            {
                return new JsonResult(null);
            }

            SubjectApiModel model = await this._service.AddAsync(subject).ConfigureAwait(false);
            return new JsonResult(subject);
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("Update")]
        public virtual async Task<IActionResult> UpdateAsync([FromBody]SubjectApiModel subject)
        {
            if (subject == null)
            {
                return new JsonResult(null);
            }

            SubjectApiModel model = await this._service.UpdateAsync(subject).ConfigureAwait(false);
            return new JsonResult(model);
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

            SubjectApiModel model = await this._service.DeleteAsync(id).ConfigureAwait(false);
            return new JsonResult(model);
        }

        #endregion
    }
}
