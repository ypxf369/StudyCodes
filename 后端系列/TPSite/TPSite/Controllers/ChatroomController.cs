using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TPSite.Controllers
{
    public class ChatroomController : Controller
    {
        public IActionResult DoubleRoom()
        {
            return View();
        }
    }
}