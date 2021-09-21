﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(128)]
        public string Author { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public byte CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime AddedOn { get; set; }

        public Book()
        {
            AddedOn = DateTime.Now;
        }
    }
}