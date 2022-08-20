using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services.Interfaces;
using Sat.Recruitment.Api.Validators.Interfaces;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {


        private readonly IUserService userService;
        private readonly IUserValidator userValidator;

        public UsersController(IUserService userService,
                               IUserValidator userValidator)
        {
            this.userService = userService;
            this.userValidator = userValidator;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var errors = "";

            userValidator.ValidateErrors(name, email, address, phone, ref errors);

            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

      

            return userService.CreateNewUser(name, email, address, phone, userType, money);
        }


    }

}
