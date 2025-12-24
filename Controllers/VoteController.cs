using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingApp.Data;

namespace VotingApp.Controllers
{
    public class VoteController : Controller
    {
        private readonly VotingDbContext _context;
        public VoteController(VotingDbContext context) => _context = context;
        [HttpPost]
        public IActionResult Vote(int voterId, int candidateId)
        {
            var voter = _context.Voters.Find(voterId);
            if (voter.HasVoted)
                return BadRequest("Voter already voted");

            var candidate = _context.Candidates.Find(candidateId);

            candidate.Votes++;
            voter.HasVoted = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
