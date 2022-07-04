using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    [HttpPost]
    public IActionResult Index()
    {
        return Ok(GamesRepository.NewFloodFillGameDto(10, 10, 4));
    }
}