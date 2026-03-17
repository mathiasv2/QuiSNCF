using QuiSNCF.Database;
using QuiSNCF.Models;

namespace QuiSNCF.Repository;

public class StationRepository(GameDbContext db)
{
    public async Task<Station?> GetStationById(int id)
    {
        return await db.Stations.FindAsync(id);
    }
    public Station GetRandomStation()
    {
        Random rdn = new Random();
        
        var today = DateOnly.FromDateTime(DateTime.Today);

        var availableStations = db.Stations
            .Where(s => s.LastTimePlayed < today || s.LastTimePlayed > today)
            .ToList();

        if (!availableStations.Any())
            return null;

        int index = rdn.Next(availableStations.Count);

        return availableStations[index];
    }
    public async Task CreateStation(Station station)
    {
        await db.Stations.AddAsync(station);
        await db.SaveChangesAsync();
    }
}