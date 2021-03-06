﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Noteit.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<MyNotes> Note { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Noteit.Models.MyNotes> MyNotes { get; set; }
    }
}