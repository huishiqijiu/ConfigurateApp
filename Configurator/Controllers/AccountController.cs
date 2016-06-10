using Configurator.Services.IServices;
using Configurator.Services.IServices.IAccountService;
using Configurator.Services.ServiceModels;
using Configurator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configurator.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        IUserAuthenticationService _authService;
        IMailService _mailService;
        IFormsAuthenticationAdapter _adapter;
        public AccountController(IUserService userService, IUserAuthenticationService authService, IMailService mailService, IFormsAuthenticationAdapter adapter)
        {
            _userService = userService;
            _authService = authService;
            _mailService = mailService;
            _adapter = adapter;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            var model = new RegistrationViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {

            if (_authService.RegisterUser(model.GetUser()) > 0)
                return RedirectToAction("Login");
            else
                return Json(new { Message = "Fail to register!" });

        }
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_authService.UserExists(model.Mail))
                    ModelState.AddModelError("mail", "Email is not registered.");
                else if (_authService.WrongPassword(model.Mail, model.Password))
                    ModelState.AddModelError("password", "Wrong Password.");
                else if (_authService.Login(model.Mail, model.Password))
                {

                    return RedirectToAction("Index", "Configurator");
                }
                else
                    return RedirectToAction("Register");
            }
            model.Password = "";
            return View(model);

        }
        public ActionResult LostPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LostPassword(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_authService.UserExists(model.LoginEmail))
                    ModelState.AddModelError("mail", "Email is not registered.");

                else
                {
                    UserModel u = _userService.GetUser(model.LoginEmail);
                    _mailService.SendPassword(model.LoginEmail, u.Password);
                }
            }
            return View("Login");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel u )
        {
            if (ModelState.IsValid)
            {
                UserModel user = _userService.GetUser(u.Mail);
                _userService.ChangePassword(user.Id, u.Password);
                return View("NewPass");
            }
            return View(u);
        }

    }
}