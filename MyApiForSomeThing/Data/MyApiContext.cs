using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApiForSomeThing.Models;

namespace MyApiForSomeThing.Data
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
        {
            
        }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<RoleCredential> RoleCredentials { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<KindMusic> KindMusics { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
