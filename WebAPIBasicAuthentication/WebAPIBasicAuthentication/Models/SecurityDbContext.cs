namespace WebAPIBasicAuthentication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class SecurityDbContext : IdentityDbContext <IdentityUser>
    {
        public SecurityDbContext()
            : base("name=SecurityDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
