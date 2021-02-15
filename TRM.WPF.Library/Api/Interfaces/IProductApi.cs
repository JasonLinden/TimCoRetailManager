using System.Collections.Generic;
using System.Threading.Tasks;
using TRM.WPF.Library.Models;

namespace TRM.WPF.Library.Api.Interfaces
{
    public interface IProductApi
    {
        Task<List<ProductModel>> GetAllProducts();
    }
}