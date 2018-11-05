using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiForSomeThing.Models
{
    public class UserAccount
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // Role Id
        public long RoleId { get; set; }
        public string Salt { get; set; }
        public int Status { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public UserInformation Information { get; set; }
        public List<Song> Songs { get; set; }
        public List<Credential> Credentials { get; set; }
        public RoleUser RoleUser { get; set; }
    }
}
