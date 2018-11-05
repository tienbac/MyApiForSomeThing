using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiForSomeThing.Models
{
    public class Song
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public string Author { get; set; }
        public string Thumbnail { get; set; }
        // Thể loại nhạc
        public long KindMusicKId { get; set; }
        public string LinkMp3 { get; set; }
        // Số lượt nghe / bài hát
        public int Turns { get; set; }
        // User Account Id: Long == Int64
        public long UserAccountId { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public int Status { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
