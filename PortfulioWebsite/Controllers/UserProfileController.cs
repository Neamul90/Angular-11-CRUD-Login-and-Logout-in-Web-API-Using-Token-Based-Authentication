using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfulioWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            int userId =Convert.ToInt32(User.Claims.First(c => c.Type == "UserID").Value);
            var user = await _context.Users.Where(a=>a.Id==userId).FirstOrDefaultAsync();
            return new
            {
                user.FullName,
                user.Email,
                user.Username
            };
        }
    }
}
