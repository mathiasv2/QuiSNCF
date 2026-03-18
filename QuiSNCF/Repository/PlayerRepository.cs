using Microsoft.EntityFrameworkCore;
using QuiSNCF.Database;
using QuiSNCF.DTO;
using QuiSNCF.Models;

namespace QuiSNCF.Repository;

public class PlayerRepository(GameDbContext db) : IPlayerRepository
{
    public async Task<List<Player>> GetPlayers()
    {
        return await db.Players.ToListAsync();
    }

    private int CalculateScore(int multiplier)
    {
        int score = 5000;
        int lostPoints = 323 * multiplier;
        score -= lostPoints;
        return score;
    }

    public async Task CreatePlayerAsync(CreatePlayerDTO player)
    {

        Player newPlayer = new Player()
        {
            Name = player.Name,
            Score = CalculateScore(player.Multiplier),
            ScoreDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
        
        await db.Players.AddAsync(newPlayer);
        await db.SaveChangesAsync();
    }
    
}