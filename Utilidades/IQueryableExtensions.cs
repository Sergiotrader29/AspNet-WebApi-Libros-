using webapi.DTOs;

namespace webapi.Utilidades
{
   
        public static class IQueryableExtensions // laestactica porque qvoy a colocar un metodo de extension .
        {
            public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
            {
                return queryable
                    .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina) // con skip me voy a salta los registros por ejemplo 
                    // si pagina es 2, 2-1=1 y me voy a saltar los primero 10 registros, para mostrar los isguientes 10 registros.
                    .Take(paginacionDTO.RecordsPorPagina); //TAKE tomo la cantidad de records pagina
            }
        }
    
}
