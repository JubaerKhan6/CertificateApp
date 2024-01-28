using LoginService.Models.AuthModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoginService.Models;

namespace LoginService.LoginRepo
{
    public class Log_inService : ILoginService
    {
        private readonly string host = "https://localhost:44360";
        public  Task<string> LoginUser(LoginModel loginModel)
        {
            string jsonData = JsonConvert.SerializeObject(loginModel);
            return JsonResponse(jsonData, "Login");
          

        }
        public  Task<string> RegisterUser(RegisterUser registerUser)
        {
            string jsonData = JsonConvert.SerializeObject(registerUser);
            return JsonResponse(jsonData, "Register");

        }
        public Task<string> OtpCheck(OneTimePassword otp)
        {
            string jsonData = JsonConvert.SerializeObject(otp);
            return JsonResponse(jsonData, $"OTPVerification");
        }
        public async Task<string> JsonResponse(string jsonData, string endpoint)
        {
            using (var client = new HttpClient())
            {

               
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                string url = $"{host}/api/Authentication/{endpoint}";
                using (var response = await client.PostAsync(url, stringContent))
                {
                    var apiresponse = response.Content.ReadAsStringAsync().Result;

                    var returnstring = "";

                    var feedback = new ApiFeedback<string>();
                    feedback = JsonConvert.DeserializeObject<ApiFeedback<string>>(apiresponse);
                    if (feedback.StatusCode == 200)
                    {
                        returnstring = "Success";
                    }
                    else
                    {
                        returnstring = feedback.Message;
                    }

                    return returnstring;

                }

            }
        }
    }
}
