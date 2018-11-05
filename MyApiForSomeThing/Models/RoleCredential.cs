using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiForSomeThing.Models
{
    public class RoleCredential
    {
        [Key]
        public long RId { get; set; }
        public string RName { get; set; }
        public string RDescription { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public int Status { get; set; }
        public List<Credential> Credentials { get; set; }
    }
}
