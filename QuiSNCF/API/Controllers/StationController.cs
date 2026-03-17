using Microsoft.AspNetCore.Mvc;
using QuiSNCF.Models;
using QuiSNCF.Repository;

namespace QuiSNCF.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StationController(StationRepository repo) : ControllerBase
{
    [HttpGet("GetStation")]
    public Station GetRandomStation()
    {
        var station = repo.GetRandomStation();
        return station;
    }
    

    [HttpPost("CreateStation")]
    public async Task CreateStation(Station station)
    {
        await repo.CreateStation(station);
    }
}