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
        
        int rendomId = rdn.Next(1, db.Stations.Count());
        var station = db.Stations.ElementAt(rendomId);

        return station;
    }

    public bool HasStationBeenAlreadyPlayed(Station station)
    {
        var diff = station.LastTimePlayed.CompareTo(DateOnly.FromDateTime(DateTime.Today));
        return diff < 0;
    }

    public async Task CreateStation(Station station)
    {
        await db.Stations.AddAsync(station);
        await db.SaveChangesAsync();
    }
}