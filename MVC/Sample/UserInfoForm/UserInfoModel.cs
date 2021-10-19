using System.ComponentModel;

namespace MVC.Sample.UserInfoForm
{
    public class UserInfoModel : IModel
    {
        private string _firstName;
        private string _lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                string prevValue = _firstName;
                _firstName = value;
                if (_firstName != prevValue)
                {
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                string prevValue = _firstName;
                _lastName = value;
                if (_firstName != prevValue)
                {
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public void Save()
        {
            // todo save code here
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
