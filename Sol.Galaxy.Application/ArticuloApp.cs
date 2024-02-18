using AutoMapper;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class ArticuloApp : IArticuloApp
    {
        private readonly IArticuloData articuloData;
        private readonly IMapper mapper;
      

        public ArticuloApp(IArticuloData articuloData, IMapper mapper)
        {
            this.articuloData = articuloData;
            this.mapper = mapper;
        }

        public async Task<Articulo> GetArticulo(int id)
        {
            Product res = await articuloData.GetByIdAsync(id);
            Articulo articulo = null;

            if (res != null)
            {
                articulo = mapper.Map<Articulo>(res);
                //articulo = new Articulo() { Codigo = res.ProductId, Nombre = res.ProductName };

            }
            return articulo;
        }

        public async Task< List<Articulo>>  GetArticulos()
        {

            List<Product> res = await articuloData.ListAllAsync();

            List<Articulo> articulos = mapper.Map<List<Articulo>>(res);

            //List<Articulo> articulos = (from x in res
            //                            select new Articulo
            //                            {
            //                                Codigo = x.ProductId,
            //                                Nombre = x.ProductName
            //                            }).ToList();

            return articulos;
        }

        public async Task<Articulo> SaveArticulo(Articulo articulo)
        {
            Product p = new Product { ProductId = articulo.Codigo, ProductName = articulo.Nombre };

            await articuloData.AddAsync(p);

            return articulo;
        }
    }
}
