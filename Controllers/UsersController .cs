using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayApi.Data;
using RaceDayApi.DTOs;

using System.Security.Claims;

namespace RaceDayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Must be logged in
    public class UsersController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public UsersController(RaceDayDbContext context)
        {
            _context = context;
        }

        //getting the logged-in user's ID from the JWT token
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        // GET: api/users/profile
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = GetUserId();
            var user = await _context.Users
                .Include(u => u.Organiser)
                .Include(u => u.Participant)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return NotFound(new { message = "User not found." });

            // Map to a safe object
            var profile = new
            {
                user.UserId,
                user.FirstName,
                user.LastName,
                user.Email,
                PhoneNumber = user.Organiser?.ContactPhone,
                Role = user.Organiser != null ? "Organiser" : "Participant"
            };

            return Ok(profile);
        }

        // PUT: api/users/profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileDto dto)
        {
            var userId = GetUserId();
            var user = await _context.Users
                .Include(u => u.Organiser)
                .Include(u => u.Participant)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return NotFound(new { message = "User not found." });

            // Update base User table
            user.FirstName = dto.FirstName.Trim();
            user.LastName = dto.LastName.Trim();

            // Update Organiser specific table if they are an organiser
            if (user.Organiser != null && !string.IsNullOrWhiteSpace(dto.PhoneNumber))
            {
                user.Organiser.ContactPhone = dto.PhoneNumber.Trim();
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Profile updated successfully." });
        }
    }
}