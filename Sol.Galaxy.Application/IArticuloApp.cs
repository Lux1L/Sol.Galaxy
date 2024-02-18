using Sol.Galaxy.Domain;

namespace Sol.Galaxy.Application
{
    public interface IArticuloApp
    {
        Task<List<Articulo>> GetArticulos();

        Task<Articulo> GetArticulo(int id);

        Task<Articulo> SaveArticulo(Articulo articulo);
    }
}
