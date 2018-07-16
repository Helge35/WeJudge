using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeJudgeHost.BL.Dal.Entities;

namespace WeJudgeHost.BL.Dal
{
    public class WeJadgeIdentityContext: IdentityDbContext
    {
        public WeJadgeIdentityContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
    }
}

