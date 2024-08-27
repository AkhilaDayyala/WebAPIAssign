using Microsoft.AspNetCore.Mvc;
using WebAPIAssign.DataContext;
using WebAPIAssign.Models; // Ensure this namespace is correct

namespace WebAPIAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public LoginController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _context.Login
                .FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(user);
        }
    }
}
