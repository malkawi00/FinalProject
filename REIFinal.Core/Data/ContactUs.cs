using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Data
{
   public class ContactUs
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
