using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace REIFinal.Core.Service
{
  public interface ILoginService
    {
        public string GetLoginToken(Users user);
        public string EmailVerification(Users user);
        public string SetNewPassword(SetNewPassword newPassword);
    }
}
