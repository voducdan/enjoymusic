using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Models
{
    public class Song
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string singer { get; set; }
        [Required]
        public string avt { get; set; }
        [Required]
        public string url { get; set; }

    }
}
