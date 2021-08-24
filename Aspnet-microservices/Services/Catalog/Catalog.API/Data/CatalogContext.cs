using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration )
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabasSettigs:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabasSettigs:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabasSettigs:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
