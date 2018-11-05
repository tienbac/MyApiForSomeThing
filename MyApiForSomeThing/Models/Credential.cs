using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyApiForSomeThing.Models
{
    public class Credential
    {
        [Key]
        public string Token { get; set; }
        // Role Credential Id
        public long RoleCredentialId { get; set; }
        public string AccessToken { get; set; }
        //User Account Id
        public long UserAccountId { get; set; }
        // Username in User Account
        public string Username { get; set; }
        // Password in User Account
        public string Password { get; set; }
        public string KeyReset { get; set; }
        public long CreatedTimeMls { get; set; }
        public long ExpiredTimeMls { get; set; }
        public int Status { get; set; }
        public UserAccount UserAccount { get; set; }
        public RoleCredential RoleCredential { get; set; }
    }
}
