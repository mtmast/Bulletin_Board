﻿using Microsoft.AspNetCore.Mvc;

namespace MTM.Web.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}