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
using DashboardApp.Models;


namespace DashboardApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private DashboardAppContext _context;

        public MessageController(ILogger<MessageController> logger, DashboardAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ====================
        // ====================== Add new Message to DB
        // ====================
        [HttpPost("/NewMessage")]
        public IActionResult NewMessage(Profile prof)
        {
            Message msg = prof.Message;
            if(ModelState.IsValid)
            {
                _context.Add(msg);
                _context.SaveChanges();
                return RedirectToAction("Profile", "Dashboard", new {id = msg.RecipientId});
            }
            else
            {
                Profile profile = new Profile();
                profile.LoggedInUserId = (int)HttpContext.Session.GetInt32("UserId");
                profile.User = _context.Users
                                .Include(u => u.MessagesRecieved)
                                    .ThenInclude(mr => mr.Author)
                                .Include(u => u.MessagesRecieved)
                                    .ThenInclude(mr => mr.CommentsOnMessage)
                                        .ThenInclude(com => com.CommentAuthor)
                                .SingleOrDefault(u => u.UserId == profile.LoggedInUserId);
                profile.Message = msg;
                profile.Comment = new Comment();
                return View("Profile", profile);
            }
        }
    }
}