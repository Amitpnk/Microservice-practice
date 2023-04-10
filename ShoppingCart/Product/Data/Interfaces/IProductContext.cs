using MongoDB.Driver;
using Product.Entities;

namespace Product.Data.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Products> Products { get; }
    }
}
