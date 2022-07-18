using ManageIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity.Data
{
    // Implementing EntityFrameworkcore identitydbcontext to set identity.
    public class SignUpDbContext : IdentityDbContext<ApplicationUser>
    {
        public SignUpDbContext(DbContextOptions<SignUpDbContext> options) : base(options)
        {

        }
    }
}
