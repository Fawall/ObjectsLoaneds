using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ObjectsLoaneds.Models;


namespace ObjectsLoaneds.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<ObjectsLoanedsModel> ObjectsLoaneds { get; set; }

    }
}
