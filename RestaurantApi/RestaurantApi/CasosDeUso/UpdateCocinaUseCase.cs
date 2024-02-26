using RestaurantApi.Repositories;

namespace RestaurantApi.CasosDeUso
{

    public interface IUpdateCocinaUseCase
    {
        Task<Models.Cocina?> Execute(Models.Cocina cocina);
    }
    public class UpdateCocinaUseCase : IUpdateCocinaUseCase
    {
        private readonly CocinaDatabaseContext _cocinaDatabaseContext;


        public UpdateCocinaUseCase(CocinaDatabaseContext cocinaDatabaseContext)
        {
            _cocinaDatabaseContext = cocinaDatabaseContext;
        }
        public async Task<Models.Cocina?>Execute(Models.Cocina cocina)
        {
            var entity = await _cocinaDatabaseContext.Get(cocina.Id);

            if (entity == null)
                return null; 

            entity.Id = cocina.Id;
            entity.Plato = cocina.Plato;
            entity.Descripcion = cocina.Descripcion;
            entity.Terminado = cocina.Terminado;

            await _cocinaDatabaseContext.Actualizar(entity);
            return entity.ToDto();
        }
    }
}
