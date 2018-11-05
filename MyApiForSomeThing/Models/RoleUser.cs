using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiForSomeThing.Models
{
    public class RoleUser
    {
        [Key]
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int Status { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public List<UserAccount> UserAccounts { get; set; }
    }
}
