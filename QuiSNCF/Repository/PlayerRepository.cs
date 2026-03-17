using QuiSNCF.Database;
using QuiSNCF.Models;

namespace QuiSNCF.Repository;

public class PlayerRepository(GameDbContext db)
{
    public List<Player> GetPlayers()
    {
        return db.Players.ToList();
    }
}