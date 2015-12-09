using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noteit.Models
{
    public class MyNotes
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}