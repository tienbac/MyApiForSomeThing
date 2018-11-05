using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyApiForSomeThing.Models
{
    public class UserInformation
    {
        [Key]
        public string Email { get; set; }
        // User Account Id
        public long UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string Introduction { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        //Status verify email
        public bool EmailVerify { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
