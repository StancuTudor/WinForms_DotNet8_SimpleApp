using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    public interface IMainService
    {
        Task<LoginOut> Login(string user, string password);
    }

    public class MainService : IMainService
    {
        public async Task<LoginOut> Login(string user, string password)
        {
            await Task.Delay(1000);

            if (user == "admin" && password == "password")
                return new LoginOut()
                {
                    UserData = new ValidateUserOut()
                    {
                        UserLogin = new UserLogin()
                        {
                            UserName = user,
                            UserId = 1
                        },
                        Result = "Success",
                        StatusCode = ValidationStatusCode.Success
                    }
                };

            return new LoginOut()
            {
                UserData = new ValidateUserOut()
                {
                    UserLogin = null,
                    Result = "Utilizator incorect",
                    StatusCode = ValidationStatusCode.Failed
                }
            };
        }
    }
}
