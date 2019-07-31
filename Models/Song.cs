using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRama.Models
{
    public class Song
    {

        public Song ()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength (150)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}