using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WaterRefillStation.Model;
using WaterRefillStation.DataLayer;
using System.Linq;
using System.Windows;

namespace WaterRefillStation.ViewModel
{
    public class LogInVM : ViewModelBase
    {
        public Employee ActiveEmployee { get; set; }

        public string UserName
        {
            get
            {
                if (ActiveEmployee == null)
                    return string.Empty;
                else
                    return ActiveEmployee.Account.UserName;
            }
        }


        public RelayCommand<string> LoginCommand
        {
            get
            {
                return new RelayCommand<string>(Login);
            }
        }

        private void Login(string password)
        {
            var employees = WaterRefillStationDbContext.DbContext.Employees;
            
            ActiveEmployee = employees.FirstOrDefault(emp=>emp.Account.UserName == this.UserName && emp.Account.Password == password);

            if(ActiveEmployee == null)
                MessageBox.Show("No Employee");
            else
                MessageBox.Show("Success");
        }
    }
}
