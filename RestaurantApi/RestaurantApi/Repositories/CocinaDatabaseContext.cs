using RestaurantApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RestaurantApi.Repositories
{
    public class CocinaDatabaseContext : DbContext
    {
        public CocinaDatabaseContext(DbContextOptions<CocinaDatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<CocinaEntity> Cocina { get; set; }

        public async Task<CocinaEntity> Get(int id)
        {
            return await Cocina.FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await Get(Id); 
            Cocina.Remove(entity);
            SaveChanges();
            return true;
        }

        public async Task<CocinaEntity> Add(CreateCocina cocina)
        {
            CocinaEntity entity = new CocinaEntity()
            {
                Id = null,
                Plato = cocina.Plato,
                Descripcion = cocina.Descripcion,
                Terminado = cocina.Terminado,

            };
            EntityEntry<CocinaEntity> response = await Cocina.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("No se puede guardar"));
        }
    }

    public class CocinaEntity
    {
        public int? Id { get; set; }
        public string Plato { get; set; }
        public string Descripcion { get; set; }
        public string Terminado { get; set; }


        public Cocina ToDto()
        {
            return new Cocina()
            {
                Id = Id ?? throw new Exception("El id no puede ser null"),
                Plato = Plato,
                Descripcion = Descripcion,
                Terminado = Terminado
            };
        }
    }
}
