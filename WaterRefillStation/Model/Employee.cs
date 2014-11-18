using GalaSoft.MvvmLight;

namespace WaterRefillStation.Model
{
    public class Employee : ObservableObject
    {
        #region Properties

        public int EmployeeID { get; set; }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                Set<string>(() => FirstName, ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set<string>(() => LastName, ref _lastName, value);
            }
        }

        private string _nickname;
        public string NickName
        {
            get
            {
                return _nickname;
            }
            set
            {
                Set<string>(() => NickName, ref _nickname, value);
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                Set<string>(() => Address, ref _address, value);
            }
        }

        private string _contactNumber;
        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                Set<string>(() => ContactNumber, ref _contactNumber, value);
            }
        }

        private string _emergencyContactNumber;
        public string EmergencyContactNumber
        {
            get
            {
                return _emergencyContactNumber;
            }
            set
            {
                Set<string>(() => EmergencyContactNumber, ref _emergencyContactNumber, value);
            }
        }

        private string _licenseNumber;
        public string LicenseNumber
        {
            get
            {
                return _licenseNumber;
            }
            set
            {
                Set<string>(() => LicenseNumber, ref _licenseNumber, value);
            }
        }

        private AdminRights _adminRights;
        public AdminRights AdminRights
        {
            get
            {
                return _adminRights;
            }
            set
            {
                Set<AdminRights>(() => AdminRights, ref _adminRights, value);
            }
        }

        private Account _account;
        public Account Account
        {
            get
            {
                return _account;
            }
            set
            {
                Set<Account>(() => Account, ref _account, value);
            }
        }
        #endregion

        #region Methods

        public Employee() { }
        #endregion
    }
}
