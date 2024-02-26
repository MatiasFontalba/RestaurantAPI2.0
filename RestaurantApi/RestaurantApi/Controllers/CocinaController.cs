using Microsoft.AspNetCore.Mvc;
using RestaurantApi.CasosDeUso;
using RestaurantApi.Models;
using RestaurantApi.Repositories;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CocinaController : Controller
    {
        private readonly CocinaDatabaseContext _cocinaDatabaseContext;
        private readonly IUpdateCocinaUseCase _updateCocinaUseCase;

        public CocinaController(CocinaDatabaseContext cocinaDatabaseContext, IUpdateCocinaUseCase updateCocinaUseCase)
        {
            _cocinaDatabaseContext = cocinaDatabaseContext;
            _updateCocinaUseCase = updateCocinaUseCase;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCocina(int Id)
        {
            var result = await _cocinaDatabaseContext.Delete(Id);

            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCocina(CreateCocina cocina)
        {
            CocinaEntity result = await _cocinaDatabaseContext.Add(cocina);

            return new CreatedResult($"http://localhost:7016/api/cocina/{result.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cocina))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCocina(Cocina cocina)
        {
            Cocina? result = await _updateCocinaUseCase.Execute(cocina);

            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

    }
}
