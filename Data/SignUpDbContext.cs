using ManageIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity.Data
{
    public class SignUpDbContext : IdentityDbContext<ApplicationUser>
    {
        public SignUpDbContext(DbContextOptions<SignUpDbContext> options) : base(options)
        {

        }
    }
}
