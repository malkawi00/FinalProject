using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REIFinal.Core.Data
{
   public class Testimonial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Massege { get; set; }
        public int IsActive { get; set; }
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
