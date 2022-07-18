using ManageIdentity.Models;
using ManageIdentity.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpRepository _signUpRepository;

        public SignUpController(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SingUp([FromBody]SignUpModel signUpModel)
        {
            var result = await _signUpRepository.SignUpAsync(signUpModel);
            if (!result.Succeeded)
                return Unauthorized();

            return Ok(result.Succeeded);
        }
    }
}
