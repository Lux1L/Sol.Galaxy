using Microsoft.AspNetCore.Authorization;
using Sol.Galaxy.Application;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using Sol.Galaxy.Utils.Logged;
using System.Runtime.CompilerServices;

namespace Sol.Galaxy.MinimalApi.Extensions
{
    public static class ConfiguracionExtensions
    {
        /// <summary>
        /// Contador de Palabras Galaxy
        /// </summary>
        /// <param name="cadena">Palabra a contar</param>
        /// <returns>Numero de letras</returns>
        public static int ContadorPalabras(this string cadena)
        {

            int cantidad = cadena.Length;
            return cantidad;

        }


        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddTransient<IArticuloApp, ArticuloApp>();
            services.AddTransient<IArticuloData, ArticuloData>();
            services.AddTransient<ISeguridadApp, SeguridadApp>();
            services.AddTransient<IUserRepositorio, UserRepositorio>();
            services.AddTransient<IInvoiceRepositorio, InvoiceRepositorio>();
            services.AddTransient<IComprobantesApp, ComproanteApp>();
            services.AddTransient<ILoggedService, LoggerServices>();


            return services;
        }


        public static WebApplication ConfigureMethods(this WebApplication app)
        {
            app.MapPost("/auth", async (ISeguridadApp seguridadApp, UserAutenticaRequest request) =>
            {

                UserAutenticateResponse resp = await seguridadApp.Autentica(request);
                if (resp == null)
                {
                    return Results.BadRequest("Credenciales no validar");
                }

                return Results.Ok(resp);

            });

            app.MapGet("/comprobantes", [Authorize] async (IComprobantesApp comprobantes) =>
            {
                return await comprobantes.List();
            });

            app.MapGet("/articulos",
                [Authorize] async (IArticuloApp articuloApp, IHttpContextAccessor httpContextAccessor) =>
            {

                string value = httpContextAccessor.HttpContext.User.FindFirst("user").Value;
                return await articuloApp.GetArticulos();
            });


            app.MapGet("/articulos/{id}", async (IArticuloApp articuloApp, int id = 0) =>
            {

                Articulo a = await articuloApp.GetArticulo(id);

                if (a == null)
                {
                    return Results.BadRequest("No se encontro el articulo");
                }

                return Results.Ok(a);

            });


            app.MapPost("/articulos", async (IArticuloApp articuloApp, Articulo articulo) =>
            {
                return Results.Ok(await articuloApp.SaveArticulo(articulo));
            });

            return app;
        }

    }




}
