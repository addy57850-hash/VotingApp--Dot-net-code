using Microsoft.AspNetCore.Mvc;
using VotingApp.Data;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : Controller
    {
        private readonly VotingDbContext _context;
        public CandidateController(VotingDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Candidates.ToList());

        [HttpPost]
        public IActionResult Post(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return Ok(candidate);
        }
    }
}
