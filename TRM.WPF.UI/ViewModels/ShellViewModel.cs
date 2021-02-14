using Caliburn.Micro;
using TRM.WPF.UI.EventModels;

namespace TRM.WPF.UI.ViewModels
{
    public class ShellViewModel : Conductor<object> // object could be a interface or type which relates to a viewModel for a form
        , IHandle<LoggedInEvent>
    {
        private readonly SalesViewModel _salesViewModel;
        private readonly IEventAggregator _events;
        private readonly SimpleContainer _container;

        public ShellViewModel( 
            SalesViewModel salesViewModel,
            IEventAggregator events,
            SimpleContainer container)
        {
            _events = events;
            _events.Subscribe(this);
            _container = container;

            _salesViewModel = salesViewModel;

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LoggedInEvent message)
        {
            ActivateItem(_salesViewModel);;
        }
    }
}
