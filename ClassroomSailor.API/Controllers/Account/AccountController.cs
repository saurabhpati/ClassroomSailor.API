using System.Threading.Tasks;
using ClassroomSailor.API.Models.Account;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomSailor.API.Controllers.Account
{
    [Route("v1/api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService<ClassroomSailorUserEntity> _service;

        public AccountController(IAccountService<ClassroomSailorUserEntity> service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterApiBindingModel model)
        {
            IdentityResult result = await this._service.RegisterAsync(model.Role, model.Username, model.Password, model.FirstName, 
                model.LastName, model.Email, model.BirthDate, model.MiddleName, model.PhoneNumber).ConfigureAwait(false);

            return new JsonResult(result);
        }
    }
}
