using Microsoft.AspNet.Identity.EntityFramework;
using PruebaMoraviaWebService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaMoraviaWebService.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
            : base("AppDbContext")
        {
            
        }

        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMap());

            //------------------------------------------------------------------------------------

            modelBuilder.Entity<IdentityUserLogin>().HasKey(t => t.UserId);

            modelBuilder.Entity<IdentityUserRole>().HasKey(t => new { t.UserId, t.RoleId });
        }
    }
}