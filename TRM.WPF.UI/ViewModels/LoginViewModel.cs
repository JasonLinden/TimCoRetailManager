using Caliburn.Micro;
using System;
using System.Threading.Tasks;
using TRM.WPF.Library.Api.Interfaces;
using TRM.WPF.Library.Models;
using TRM.WPF.UI.EventModels;

namespace TRM.WPF.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IAPIHelper _apiHelper;
        private readonly IEventAggregator _events;

        private string _userName;
        private string _password;
        private string _errorMessage;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _events = events;
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

        public bool IsErrorVisible
        {
            get
            {
                return !string.IsNullOrEmpty(_errorMessage);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
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
                ErrorMessage = string.Empty;

                AuthenticatedUser userSession = await _apiHelper.AuthenticateAsync(_userName, _password);
                await _apiHelper.GetLoggedInUserAsync(userSession.AccessToken);

                _events.PublishOnUIThread(new LoggedInEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
