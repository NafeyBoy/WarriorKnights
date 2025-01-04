using Microsoft.AspNetCore.Mvc;
using PlayerServiceAPI.Models;

namespace PlayerServiceAPI.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly PlayerDbContext _context;
        public PlayerController(PlayerDbContext playerDbContext){
            _context = playerDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetAllPlayers(){
            return _context.Players;
        }

        [HttpGet("{playerId:int}")]
        public async Task<ActionResult<Player>> GetById(int playerId){
            var player = await _context.Players.FindAsync(playerId);
            return player;
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(Player player){
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Player>> Update(Player player){
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{playerId:int}")]
        public async Task<ActionResult<Player>> Delete(int playerId){
            var player = await _context.Players.FindAsync(playerId);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}