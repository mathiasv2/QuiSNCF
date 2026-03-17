using Microsoft.AspNetCore.Mvc;
using QuiSNCF.Models;
using QuiSNCF.Repository;

namespace QuiSNCF.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StationController(StationRepository repo) : ControllerBase
{
    [HttpGet("todaysStation")]
    public async Task<Station?> GetRandomStation()
    {
        var station = await repo.GetTodayStation();
        if (station == null)
            return null;
        return station;
    }
    

    [HttpPost("createStation")]
    public async Task CreateStation(Station station)
    {
        await repo.CreateStation(station);
    }
}