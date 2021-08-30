using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Dto
{
   public class DtoSaleContracts
    {
      
        public DateTime ContractDate { get; set; }
        public double TotalPayment { get; set; }
        public string Document { get; set; }
        public double Commission { get; set; }
   
        public string UserName { get; set; }
    
        public string AdvTitle { get; set; }
    }
}
