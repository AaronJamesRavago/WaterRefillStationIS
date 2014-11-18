using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace WaterRefillStation.Model
{
    public class Account : ViewModelBase
    {
        public int AccountID { get; set; }

        [Key, ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                Set<string>(() => UserName, ref _userName, value);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set<string>(() => Password, ref _password, value);
            }
        }


    }
}
