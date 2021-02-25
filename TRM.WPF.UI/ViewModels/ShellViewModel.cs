using Caliburn.Micro;
using TRM.WPF.UI.EventModels;

namespace TRM.WPF.UI.ViewModels
{
    public class ShellViewModel : Conductor<object> // object could be a interface or type which relates to a viewModel for a form
        , IHandle<LoggedInEvent>
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(
            IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LoggedInEvent message)
        {
            ActivateItem(IoC.Get<SalesViewModel>());;
        }
    }
}
