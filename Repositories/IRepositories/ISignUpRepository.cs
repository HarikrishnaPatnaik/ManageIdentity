using ManageIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity.Repositories.IRepositories
{
    public interface ISignUpRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}
