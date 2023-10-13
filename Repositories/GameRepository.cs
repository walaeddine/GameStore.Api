
using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositories;
public class GameRepository : IGameRepository
{
    protected GameStoreContext _context;
    public GameRepository(GameStoreContext context) => _context = context;
    public async Task<IEnumerable<Game>> GetAllAsync() => await _context.Games.AsNoTracking().ToListAsync();
    public async Task<Game?> GetAsync(int id) => await _context.Games.FindAsync(id);
    public async Task CreateAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Game updatedGame)
    {
        _context.Games.Update(updatedGame);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id) =>
        await _context.Games.Where(g => g.Id.Equals(id)).ExecuteDeleteAsync();
}