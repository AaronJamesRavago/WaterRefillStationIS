using GalaSoft.MvvmLight;

namespace WaterRefillStation.Model
{
    public class Customer : ObservableObject
    {
        public int CustomerID { get; set; }

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
    }
}
