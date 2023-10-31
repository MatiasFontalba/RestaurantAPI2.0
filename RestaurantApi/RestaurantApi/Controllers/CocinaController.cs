using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Repositories;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CocinaController : Controller
    {
        private readonly CocinaDatabaseContext _cocinaDatabaseContext;

        public CocinaController(CocinaDatabaseContext cocinaDatabaseContext)
        {
            _cocinaDatabaseContext = cocinaDatabaseContext;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Cocina>))]
        public async Task<IActionResult> GetCocinas()
        {
            var result = _cocinaDatabaseContext.Cocina.Select(c=>c.ToDto()).ToList();

            return new OkObjectResult(result);
        }
        //api/cocina/{Id}
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cocina))]
        public async Task<IActionResult> GetCocina(int Id)
        {
            CocinaEntity result = await _cocinaDatabaseContext.Get(Id);

            return new OkObjectResult(result.ToDto());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCocina(int Id)
        {
            var result = await _cocinaDatabaseContext.Delete(Id);

            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCocina(CreateCocina cocina)
        {
            CocinaEntity result = await _cocinaDatabaseContext.Add(cocina);

            return new CreatedResult($"https://localhost:7016/api/cocina/{result.Id}", null);
        }


    }
}
