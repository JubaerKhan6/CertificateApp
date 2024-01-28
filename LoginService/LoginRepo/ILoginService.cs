using LoginService.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.LoginRepo
{
    public interface ILoginService
    {
        Task<string> LoginUser(LoginModel loginModel);
        Task<string> RegisterUser(RegisterUser registerUser);
        Task<string> OtpCheck(OneTimePassword otp);
    }

}
