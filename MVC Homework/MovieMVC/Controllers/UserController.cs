﻿using Microsoft.AspNetCore.Mvc;

namespace MovieMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
