using Microsoft.EntityFrameworkCore;

namespace webapi.Utilidades
{

        public static class HttpContextExtensions //con el http context voy a traer la cantidad total de registros y lo pongo en la cabezera
    {

    
            public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext httpContext,// T  es generico
                IQueryable<T> queryable)
            {
                if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

                double cantidad = await queryable.CountAsync(); // con countasync voy a contar los registros de las tablas.
                                                                // que va a obtener por IQueryable
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString()); //mostrar la cantidad de registros
            }
        }
}

