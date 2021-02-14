namespace TRM.WPF.Library.Models
{
    public interface ILoggedInUser
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
    }

    public class LoggedInUser : ILoggedInUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
