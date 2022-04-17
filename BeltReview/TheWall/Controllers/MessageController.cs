using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;


namespace TheWall.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private TheWallContext _context;

        public MessageController(ILogger<MessageController> logger, TheWallContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Home Route - Display Homepage
        // ====================
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                Dashboard dash = new Dashboard();
                dash.NewMessage = new Message();
                dash.Messages = _context.Messages
                                .Include(msg => msg.Author)
                                .Include(msg => msg.CommentsOnMessage)
                                    .ThenInclude(cmt => cmt.CommentAuthor)
                                .ToList();
                dash.User = _context.Users
                                .SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
                return View(dash);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // ====================
        // ====================== Add new Message to DB
        // ====================
        [HttpPost("/NewMessage")]
        public IActionResult NewMessage(Dashboard mod)
        {
            Message msg = mod.NewMessage;
            if(ModelState.IsValid)
            {
                _context.Add(msg);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                Dashboard dash = new Dashboard();
                dash.NewMessage = msg;
                dash.Messages = _context.Messages
                                .Include(msg => msg.Author)
                                .Include(msg => msg.CommentsOnMessage)
                                    .ThenInclude(cmt => cmt.CommentAuthor)
                                .ToList();
                dash.User = _context.Users
                                .SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
                return View("Dashboard", dash);
            }
        }

    }
}