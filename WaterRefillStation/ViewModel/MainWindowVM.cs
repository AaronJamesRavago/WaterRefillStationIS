using GalaSoft.MvvmLight;
using WaterRefillStation.Model;

namespace WaterRefillStation.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private Employee _loggedEmployee;
        public Employee LoggedEmployee
        {
            get
            {
                return _loggedEmployee;
            }
            set
            {
                Set<Employee>(() => LoggedEmployee, ref _loggedEmployee, value);
            }
        }
    }
}
