using Dapper;
using MimeKit;
using REIFinal.Core.Common;
using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace REIFinal.Infra.Repository
{
    public class LoginRepository : ILoginReopsitory
    {
        private readonly IDBContext DBContext;

        public LoginRepository(IDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public string EmailVerification(Users user)
        {
            if (user.Email == null || user.Email == "")
            {
                //if Email from body is null
                return "EmptyEmail";

            }
            else
            {
                //if Email from body is not null , Check Email
                var p = new DynamicParameters();
                p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                var result = DBContext.connection.Query<Users>("EmailVerification", p, commandType: CommandType.StoredProcedure);
                var checkEmail = result.SingleOrDefault();

                if (checkEmail != null)
                {
                    //if Email is found , send Email to rest PassWord
                    Random random = new Random();
                    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var Charsarr = new char[8];


                    for (int i = 0; i < Charsarr.Length; i++)
                    {
                        Charsarr[i] = characters[random.Next(characters.Length)];
                    }

                    var randomPassWord = new String(Charsarr);

                    MimeMessage message = new MimeMessage();

                    MailboxAddress from = new MailboxAddress("Real Estate Investment",
                    "rinvestment04@gmail.com");
                    message.From.Add(from);

                    MailboxAddress to = new MailboxAddress("User",
                    "" + user.Email + "");
                    message.To.Add(to);

                    message.Subject = "Reset Password";

                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<h3>Hi " + checkEmail.FirstName + "  " + checkEmail.LastName + " , </h3>" +
                        "<p>You are receiving this email because we received a password reset request for your account.</p>" +
                        "<p>Your Password is : " + randomPassWord + "</p>" +
                        "Regards" +
                        "<p>Real Estate Investment</p>";
                    message.Body = bodyBuilder.ToMessageBody();

                    using (var clinte = new SmtpClient())
                    {
                        clinte.Connect("smtp.gmail.com", 587, false);
                        clinte.Authenticate("rinvestment04@gmail.com", "B12345678");

                        clinte.Send(message);
                        clinte.Disconnect(true);

                    }
                    var UpdatePass = new DynamicParameters();
                    UpdatePass.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    UpdatePass.Add("@Password", randomPassWord, dbType: DbType.String, direction: ParameterDirection.Input);

                    var Updateresult = DBContext.connection.ExecuteAsync("UpdatePassword", UpdatePass, commandType: CommandType.StoredProcedure);
                    if (Updateresult != null)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }

                }
                else
                {
                    //if Email is Not found  
                    return "false";
                }
                
            }
        }

        public Login GetLoginToken(Users user)
        {
            var p = new DynamicParameters();

            p.Add("@Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = DBContext.connection.Query<Login>("Login", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public string SetNewPassword(SetNewPassword newPassword)
        {
            if (newPassword.OldPassword == null && newPassword.NewPassword == null)
            {
                return "New Password Or Old Password Can`t Empty";
            }
            else {
                if (newPassword.NewPassword == newPassword.ConfirmNewPassword &&
                   newPassword.NewPassword != null &&
                   newPassword.NewPassword != "")
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", newPassword.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    var result = DBContext.connection.Query<Users>("GetUserById", p, commandType: CommandType.StoredProcedure);
                    var checkUser = result.SingleOrDefault();
                    if (checkUser != null)
                    {
                        if (checkUser.Password == newPassword.OldPassword)
                        {
                                var UpdatePass = new DynamicParameters();
                                UpdatePass.Add("@Email", checkUser.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                                UpdatePass.Add("@Password", newPassword.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);

                                var Updateresult = DBContext.connection.ExecuteAsync("UpdatePassword", UpdatePass, commandType: CommandType.StoredProcedure);
                                
                                    return "Updated Password";
                        }
                        else {
                            return "Old password wrong";
                        }
                    }
                    else {
                        return "Not Found User ";
                    }

                }
                else {
                    return "Password Dose Not Match Or Empty";
                }
            }
            
        }
    }
}
