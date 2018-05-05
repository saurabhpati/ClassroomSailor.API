using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.API.Models.User;
using ClassroomSailor.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers.Account
{
    [Route("v1/api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService<ClassroomSailorUserApiModel> _service;

        public AccountController(IAccountService<ClassroomSailorUserApiModel> service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]ClassroomSailorUserApiModel model)
        {
            ClassroomSailorUserApiModel user = await this._service.RegisterAsync(model, model.Password, model.Role).ConfigureAwait(false);
            return new JsonResult(user);
        }

        #region Get

        [Route("{id}")]
        public async Task<IActionResult> GetById(String id)
        {
            ClassroomSailorUserApiModel entity = await this._service.GetByIdAsync(id).ConfigureAwait(false);
            return new JsonResult(entity);
        }

        [Route("{email}")]
        public async Task<IActionResult> GetByEmail(String email)
        {
            ClassroomSailorUserApiModel user = await this._service.GetByEmailAsync(email).ConfigureAwait(false);
            return new JsonResult(user);
        }

        public async Task<IActionResult> Get()
        {
            IEnumerable<ClassroomSailorUserApiModel> users = await this._service.GetAllAsync().ConfigureAwait(false);
            return new JsonResult(users);
        }

        #endregion

        #region Add

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> PostAsync([FromBody]ClassroomSailorUserApiModel model)
        {
            if (model == null)
            {
                return new JsonResult(null);
            }

            ClassroomSailorUserApiModel user = await this._service.AddAsync(model).ConfigureAwait(false);
            return new JsonResult(user);
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody]ClassroomSailorUserApiModel model)
        {
            if (model == null)
            {
                return new JsonResult(null);
            }

            ClassroomSailorUserApiModel user = await this._service.UpdateAsync(model).ConfigureAwait(false);
            return new JsonResult(user);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(String id)
        {
            ClassroomSailorUserApiModel user = await this._service.DeleteAsync(id).ConfigureAwait(false);
            return new JsonResult(user);
        }

        #endregion
    }
}
