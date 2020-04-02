using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Models
{
    public class SongDetail
    {
        public SongDetail()
        {
            this.download = 0;
            this.listen = 0;
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string singer { get; set; }
        [Required]
        public string composer { get; set; }
        [Required]
        public int category { get; set; }
        [Required]
        public int listen { get; set; }
        [Required]
        public int download { get; set; }
        [Required]
        public int publish_year { get; set; }
        public string avt { get; set; }
        public string lyric { get; set; }
        public string url { get; set; }
        public string path { get; set; }
    }
}
