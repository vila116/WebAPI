using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcandidateController : ControllerBase
    {
        private readonly DonationDBContext _context;
        public DcandidateController(DonationDBContext context)
        {
            _context = context;
        }
        // Get : api/Dcandidate/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDcandidates()
        {

            return await _context.dCandidates.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDcandidate(int id)
        {
            var _dcandidate = await _context.dCandidates.FindAsync(id);
            if (_dcandidate==null)
                return NotFound();
            return _dcandidate;

        }

    }
}
