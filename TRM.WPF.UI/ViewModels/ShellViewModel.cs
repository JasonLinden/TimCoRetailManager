using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRM.WPF.UI.ViewModels
{
    public class ShellViewModel : Conductor<object> // object could be a interface or type which relates to a viewModel for a form
    {
        private readonly LoginViewModel _loginViewModel;

        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;

            ActivateItem(_loginViewModel);
        }
    }
}
