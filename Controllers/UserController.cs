using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMongoDB.Models;
using MvcMongoDB.Services;

namespace MvcMongoDB.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return RedirectToAction("Privacy");
            }

            return View(user);
        }

        public IActionResult Privacy()
        {
            var users = _userService.GetUsers();

            return View(users);
        }
    }
}
