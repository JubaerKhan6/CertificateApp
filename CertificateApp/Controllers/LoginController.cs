using LoginService.Models.AuthModels;
using Microsoft.AspNetCore.Mvc;
using LoginService.LoginRepo;
using LoginService.UnitOfWork;



namespace CertificateApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _uow;
        private const string SUserName = "_Name";
        public LoginController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginModel loginModel) {
           var response= await _uow.Log_inService.LoginUser(loginModel);
            if(response.Equals("Success"))
            {

                HttpContext.Session.SetString(SUserName, loginModel.UserName);
                return RedirectToAction("OTPView");
            }
            else
            {
                @TempData["response"] = response;
                return RedirectToAction("Index");
            }
           
        }
        public async Task<IActionResult> RegisterView()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var response = await _uow.Log_inService.RegisterUser(registerUser);
            if (response.Equals("Success"))
            {
                @TempData["response"] = "Registration Successful";
                return RedirectToAction("Index");
            }
            else
            {
                @TempData["response"] = response;
                return RedirectToAction("Index");
            }
        }
        public async Task <IActionResult> OTPView()
        {
            return View();
        }
        public async Task< IActionResult > OTPVerification(string otp)
        {
           var otpmodel = new OneTimePassword();
            otpmodel.Otp = otp;
            otpmodel.Userid = HttpContext.Session.GetString(SUserName);
            var response = await _uow.Log_inService.OtpCheck(otpmodel);
            if (response.Equals("Success"))
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                @TempData["response"] = response;
                return RedirectToAction("OTPView");
            }


           
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
