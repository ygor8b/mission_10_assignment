// BowlersController.cs
// API controller that handles HTTP requests for bowler data

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

namespace BowlingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Route: /api/bowlers
    public class BowlersController : ControllerBase
    {
        // Database context injected via dependency injection
        private readonly BowlingContext _context;

        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        // GET /api/bowlers — returns bowler info for Marlins and Sharks only
        [HttpGet]
        public IActionResult GetBowlers()
        {
            var bowlers = _context.Bowlers
                .Include(b => b.Team) // Join the Team table to access TeamName
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks") // Filter to only these two teams
                .Select(b => new // Project only the fields the frontend needs
                {
                    b.BowlerFirstName,
                    b.BowlerMiddleInit,
                    b.BowlerLastName,
                    TeamName = b.Team.TeamName,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber
                })
                .ToList();

            return Ok(bowlers); // Return 200 OK with the bowler list as JSON
        }
    }
}