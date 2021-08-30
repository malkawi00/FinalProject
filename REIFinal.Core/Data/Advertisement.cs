using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REIFinal.Core.Data
{
   public class Advertisement
    {
        public int? Id { get; set; }
      
        public int Status { get; set; }
        
        public int IsActive { get; set; }
      
        public int IsValid { get; set; }
      
        public double lat { get; set; }
        
        public double lin { get; set; }
        
        [Key]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
       
        [Key]
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public int Floor { get; set; }
        public int NumOfBathrooms { get; set; }
        public int NumOfRooms { get; set; }
        public int Age { get; set; }
        public int SurfaceArea { get; set; }
        public string Description { get; set; }
        public string AdvTitle { get; set; }
        public double Price { get; set; }
        [Required]
        public DateTime ModifyAt { get; set; }
        public int Furnished { get; set; }
        public int AdvertisementId { get; set; }
        public int LandArea { get; set; }
        public int NumOfFloor { get; set; }
        public string CategoryName { get; set; }
        public string Username { get; set; }
        public string[] arrImageSrc { get; set; }
        public string ImageSrc { get; set; }

    }
}
