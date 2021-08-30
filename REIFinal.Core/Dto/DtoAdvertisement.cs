using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REIFinal.Core.Dto
{
    public class DtoAdvertisement
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Active { get; set; }
        public int Valid { get; set; }

        [Required]
        [Column("UserName")]

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }
}
