using Newtonsoft.Json;

namespace TRM.WPF.UI.Models
{
    public class AuthenticatedUser
    {
        [JsonProperty("Access_Token")]
        public string AccessToken { get; set; }
        public string UserName { get; set; }
    }
}
