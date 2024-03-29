﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicRama.Models
{
    public class User
    {

        public User()
        {
            Uploads = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public ICollection<Song> Uploads { get; set; }

    }
}