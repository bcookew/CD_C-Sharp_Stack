using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BankAccountsContext _context;

        public HomeController(ILogger<HomeController> logger, BankAccountsContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Home Route - Display Homepage
        // ====================
        public IActionResult Index()
        {
            return View();
        }

        // ====================
        // ====================== Registration form loader
        // ====================
        [HttpGet("RegistrationForm")]
        public IActionResult RegistrationForm()
        {
            return PartialView("_Register");
        }
        // ====================
        // ====================== Register - manage registration and admit on UserAccount
        // ====================
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("_Register");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    User u = _context.Users.FirstOrDefault(us => us.Email == user.Email); 
                    HttpContext.Session.SetInt32("UserId", u.UserId);
                    HttpContext.Session.SetString("FirstName", u.FirstName);
                    return RedirectToAction("UserAccount");
                }
            }
            else
            {
                return View("_Register");
            }
        }

        // ====================
        // ====================== Login Form loader
        // ====================
        [HttpGet("LoginForm")]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        // ====================
        // ====================== Login route - Check credential and admit or display errors
        // ====================
        [HttpPost("Login")]
        public IActionResult Login(LoginView formUser)
        {
            if(ModelState.IsValid)
            {
                var dbUser = _context.Users.SingleOrDefault(u => u.Email == formUser.Email);
                if(dbUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("_Login");
                }
                var Hasher = new PasswordHasher<LoginView>();
                if (Hasher.VerifyHashedPassword(formUser,dbUser.Password,formUser.Password) == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Login");
                    ModelState.AddModelError("Password", "Invalid Login");
                    return View("_Login");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                    HttpContext.Session.SetString("FirstName", dbUser.FirstName);
                    return RedirectToAction("UserAccount");
                }

            }
            else
            {
                return View("_Login");
            }
        }

        // ====================
        // ======================  User Account
        // ====================
        [HttpGet("UserAccount")]
        public IActionResult UserAccount()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                Account model = new Account();
                model.user = _context.Users
                    .SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                model.transaction = new Transaction();
                model.Transactions = _context.Transactions
                    .Where(t => t.UserId == model.user.UserId)
                    .ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // ====================
        // ====================== POST Transaction
        // ====================
        public IActionResult AddTransaction(Transaction trans)
        {
            User user = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            
            if(ModelState.IsValid)
            {
                if(user.Balance + trans.Amount >= 0)
                {
                    user.Balance += trans.Amount;
                    trans.UserId = user.UserId;
                    _context.Add(trans);
                    _context.SaveChanges();
                    return RedirectToAction("UserAccount");
                }
                else
                {
                    ModelState.AddModelError("Amount","Not enough money Available");
                    Account BalanceModel = new Account();
                    BalanceModel.transaction = trans;
                    BalanceModel.user = user;
                    BalanceModel.Transactions = _context.Transactions
                    .Where(t => t.UserId == BalanceModel.user.UserId)
                    .ToList();
                    return View("UserAccount", BalanceModel);
                }
            }
            else
            {
                Account InValidModel = new Account();
                InValidModel.transaction = trans;
                        InValidModel.user = user;
                        InValidModel.Transactions = _context.Transactions
                        .Where(t => t.UserId == InValidModel.user.UserId)
                        .ToList();
                return View("UserAccount",InValidModel);
            }
        }

        // ====================
        // ====================== Logout - Clear Session and Redir to Homepage
        // ====================
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // ====================
        // ====================== Error Catch
        // ====================

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
