using Microsoft.AspNetCore.Mvc;
using VotingApp.Data;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("api/voters")]
    public class VoterController : Controller
    {
        private readonly VotingDbContext _context;
        public VoterController(VotingDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Voters.ToList());

        [HttpPost]
        public IActionResult Post(Voter voter)
        {
            _context.Voters.Add(voter);
            _context.SaveChanges();
            return Ok(voter);
        }
    }
}
