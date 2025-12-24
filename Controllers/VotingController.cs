using Microsoft.AspNetCore.Mvc;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingController : Controller
    {
        static List<Voter> voters = new()
    {
        new() { Id = 1, Name = "Pepi", HasVoted = false },
        new() { Id = 2, Name = "Rumcajs", HasVoted = true }
    };

        static List<Candidate> candidates = new()
    {
        new() { Id = 1, Name = "Johnny Bravo", Votes = 2 },
        new() { Id = 2, Name = "Pluto", Votes = 5 }
    };

        [HttpGet("voters")]
        public IActionResult GetVoters() => Ok(voters);

        [HttpGet("candidates")]
        public IActionResult GetCandidates() => Ok(candidates);

        [HttpPost("vote")]
        public IActionResult Vote(int voterId, int candidateId)
        {
            var voter = voters.FirstOrDefault(v => v.Id == voterId);
            var candidate = candidates.FirstOrDefault(c => c.Id == candidateId);

            if (voter == null || candidate == null || voter.HasVoted)
                return BadRequest("Invalid vote");

            voter.HasVoted = true;
            candidate.Votes++;

            return Ok();
        }
    }
}
