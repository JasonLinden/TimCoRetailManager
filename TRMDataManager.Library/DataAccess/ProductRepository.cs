using System.Collections.Generic;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductRepository
    {
        public List<ProductEntity> GetProducts()
        {
            SqlDataAccess sqlData = new SqlDataAccess();

            List<ProductEntity> data = sqlData.LoadData<ProductEntity>("[dbo].[sp_GetAllProducts]", "TRMData");

            return data;
        }
    }
}
