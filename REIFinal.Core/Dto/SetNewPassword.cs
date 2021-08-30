using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Dto
{
  public  class SetNewPassword
    {
        public int  id { get; set; }
        public string  OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
