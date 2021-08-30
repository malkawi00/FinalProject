using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Dto
{
   public class DtoRentContracts
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ExtraInformation { get; set; }
        public string Document { get; set; }
        public double Paid { get; set; }
        public DateTime DateCreated { get; set; }
        
        public string Username { get; set; }
       
        public string AdvTitle { get; set; }
    }
}
