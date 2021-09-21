using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books.Models.ViewModels
{
    public class BookFormViewModel
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
        [Display(Name ="Categories")]
        public byte CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}