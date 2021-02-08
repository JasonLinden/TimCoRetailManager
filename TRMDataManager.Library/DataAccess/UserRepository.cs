using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserRepository
    {
        public List<UserEntity> GetUserById(string userId)
        {
            SqlDataAccess sqlData = new SqlDataAccess();

            List<UserEntity> data = sqlData.LoadData<UserEntity>("[dbo].[sp_GetUser]", new { UserId = userId }, "TRMData");

            return data;
        }
    }
}
