using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REIFinal.Core.Data
{
   public class Payment
    {
        public int Id { get; set; }
        public DateTime PayAt { get; set; }
        public double PaymentAmount { get; set; }
        [Key]
        [ForeignKey("RentContract")]
        public int RentContractId { get; set; }

    }

}
