using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REIFinal.Core.Data
{
   public class FavoritAdv
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Key]
        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }
    }
}
