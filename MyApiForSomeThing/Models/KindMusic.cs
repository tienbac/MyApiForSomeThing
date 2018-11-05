using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyApiForSomeThing.Models
{
    public class KindMusic
    {
        [Key]
        public long KId { get; set; }
        public string KName { get; set; }
        public string KDescription { get; set; }
        public int Status { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public List<Song> Songs { get; set; }
    }
}
