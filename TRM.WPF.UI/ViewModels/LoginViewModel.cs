using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRM.WPF.UI.Helpers;

namespace TRM.WPF.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IAPIHelper _apiHelper;
        private string _userName;
        private string _password;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
            }
        }

        public async Task Login()
        {
            try
            {
                var result = await _apiHelper.AuthenticateAsync(_userName, _password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // throw;
            }
        }
    }
}
