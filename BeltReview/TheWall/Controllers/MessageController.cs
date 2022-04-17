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
            return View();
        }
    }
}