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
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private DashboardAppContext _context;

        public CommentController(ILogger<CommentController> logger, DashboardAppContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        // ====================
        // ====================== Add new Message to DB
        // ====================
        [HttpPost("/AddComment")]
        public IActionResult AddComment(Profile prof) {
            Comment cmt = prof.Comment;
            if(ModelState.IsValid)
            {
                _context.Add(cmt);
                _context.SaveChanges();
                return RedirectToAction("Profile", "Dashboard", new {id = cmt.MessageRecipientId});
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
                profile.Message = new Message();
                profile.Comment = cmt;
                return View("Profile", profile);
            }
        }
    }
}