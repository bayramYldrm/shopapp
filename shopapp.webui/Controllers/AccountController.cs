using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.webui.EmailServices;
using shopapp.webui.Extensions;
using shopapp.webui.Identity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;
        
        public AccountController(ICartService cartService,UserManager<User> userManager,SignInManager<User> signInManager,IEmailSender emailSender)
        {
            _cartService = cartService;
            _userManager=userManager;
            _signInManager=signInManager;
            _emailSender =emailSender;
        }

        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {   
                return View(model);
            }

            // var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user==null)
            {
                ModelState.AddModelError("","No account has been created with this username before.");
                return View(model);
            } 

            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("","Please confirm your membership by clicking the link sent to your email account.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

            if(result.Succeeded) 
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("","The entered username or password is incorrect.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName  = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email    
            };           

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                // generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new {
                    userId = user.Id,
                    token = code
                });

                // email
                await _emailSender.SendEmailAsync(model.Email,
                    "Dear WTT Technology Shopping Site User," +
                    "Welcome aboard! You've reached the final step to complete your registration. To ensure the security of your account and provide you with the best shopping experience, please confirm your email address." +
                    "To confirm your email address, follow these steps: Click on the Confirm Email Address link and you'll be directed to our verification page. There, you can follow the necessary steps to finalize your registration." +
                    "If you received this email by mistake, please disregard it. However, if you've signed up for WTT Technology Shopping Site and are expecting this email, please click on the verification link to complete the process.",
                    $"Please click the link to confirm your email account. <a href='https://localhost:5001{url}'>Click the link</a>" +
                    "If you have any questions or concerns, feel free to reach out to us. We're here to help." +
                    "WTT Technology Shopping Site Team");

                return RedirectToAction("Login","Account");
            }           

            ModelState.AddModelError("","An unknown error occurred. Please try again.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title="Session closed.",
                Message="Your account has been securely closed.",
                AlertType="warning"
            });
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token ==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title="Invalid token.",
                    Message="Invalid token.",
                    AlertType="danger"
                });
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user,token);
                if(result.Succeeded)
                {
                    // cart objesini oluştur.
                    _cartService.InitializeCart(user.Id);
                    
                    TempData.Put("message", new AlertMessage()
                    {
                        Title="Your account has been confirmed.",
                        Message="Your account has been confirmed.",
                        AlertType="success"
                    });
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title="Your account has not been confirmed.",
                Message="Your account has not been confirmed.",
                AlertType="warning"
            });
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title="Null Email Address Error",
                    Message=$"Email address cannot be null. Please provide a valid email address.",
                    AlertType="danger"
                }); 
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if(user==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title="Null User Error",
                    Message=$"User information cannot be null. Please specify a valid user.",
                    AlertType="danger"
                });
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword","Account",new {
                userId = user.Id,
                token = code
            });
            TempData.Put("message", new AlertMessage()
                {
                    Title="Password Reset Link Sent to Your Email Address",
                    Message=$"An email has been sent to your email address with a link to reset your password.",
                    AlertType="warning"
                });  

            // email
            await _emailSender.SendEmailAsync(
                Email,
                "Reset Password",
                $"Welcome to WTT Technology Shopping Site. It appears that you are experiencing an issue with your account. If you have forgotten your password, please click the link below to reset it. If you did not make this request or if you need assistance, please feel free to contact us. We wish you enjoyable shopping experiences. <a href='https://localhost:5001{url}'>Password Reset Link</a> Best Regards, WTT Technology Shopping Site Customer Service"
            );
            return RedirectToAction("Index","Home");
        }

        public IActionResult ResetPassword(string userId,string token)
        {
            if(userId==null || token==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title="Null User or Token Error",
                    Message=$"User or token cannot be null. Please provide valid user and token.",
                    AlertType="danger"
                });
                return RedirectToAction("Index","Home");
            }

            var model = new ResetPasswordModel {Token=token};

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user==null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title="Null User Error",
                    Message=$"User information cannot be null. Please specify a valid user.",
                    AlertType="danger"
                });
                return RedirectToAction("Home","Index");
            }

            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

            if(result.Succeeded)
            {   TempData.Put("message", new AlertMessage()
                {
                    Title="Password Reset Successful",
                    Message=$"Password reset process has been successful.",
                    AlertType="success"
                });
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }     

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}