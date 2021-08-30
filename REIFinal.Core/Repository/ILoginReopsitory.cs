using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Repository
{
   public interface ILoginReopsitory
    {
        public Login GetLoginToken(Users user);
        public string EmailVerification(Users user);
        public string SetNewPassword(SetNewPassword newPassword);
    }
}
