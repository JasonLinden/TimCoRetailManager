using System.Threading.Tasks;
using TRM.WPF.UI.Models;

namespace TRM.WPF.UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
    }
}