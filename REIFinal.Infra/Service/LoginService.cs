using Microsoft.IdentityModel.Tokens;
using MimeKit;
using REIFinal.Core.Data;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MailKit.Net.Smtp;
using System.Text;
using REIFinal.Core.Dto;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace REIFinal.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginReopsitory iLoginReopsitory;

        public LoginService(ILoginReopsitory iLoginReopsitory)
        {
            this.iLoginReopsitory = iLoginReopsitory;
        }

        public string EmailVerification(Users user)
        {

            if (iLoginReopsitory.EmailVerification(user) == "true")
            {
                //if Email is found , send Email to rest PassWord

                return "We Send Email To Reset Password";
            }
            else if (iLoginReopsitory.EmailVerification(user) == "EmptyEmail")
            {
                //if Email from Body Is null
                return "Pleas Enter Your Email";
            }
            else
            {
                //if Email is not found 
                return "Eamil not found";
            }
        }

        public string GetLoginToken(Users user)
        {
            var result = iLoginReopsitory.GetLoginToken(user);
            if (result == null)
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
            var tokendesciptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.PrimarySid,result.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.Role, result.RoleName)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenhandler.CreateToken(tokendesciptor);
            return tokenhandler.WriteToken(token);


        
    }

        public string SetNewPassword(SetNewPassword newPassword)
        {
           return iLoginReopsitory.SetNewPassword(newPassword);
        }
    }
}
