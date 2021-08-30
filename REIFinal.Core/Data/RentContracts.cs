using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REIFinal.Core.Data
{
   public class RentContracts
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ExtraInformation { get; set; }
        public string Document { get; set; }
        public double Paid { get; set; }
        public DateTime DateCreated { get; set; }
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Key]
        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }
    }
}
