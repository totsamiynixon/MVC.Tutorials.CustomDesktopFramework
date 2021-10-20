using MVC.EditUserInfoForm.Domain;
using System.ComponentModel;

namespace MVC.EditUserInfoForm.Application
{
    public class EditUserInfoPageModel : IModel
    {
        private readonly UserInfoService _userInfoService;

        private string _firstName;
        private string _lastName;

        public EditUserInfoPageModel(UserInfoService userInfoService)
        {
            // connect Application Model with Domain Model
            _userInfoService = userInfoService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.Equals(value, _firstName)) return;

                _firstName = value;
                OnPropertyChanged(nameof(FirstName));

            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.Equals(value, _lastName)) return;

                _lastName = value;
                OnPropertyChanged(nameof(LastName));

            }
        }

        public void Initialize()
        {
            var userInfoDTO = _userInfoService.Get();
            FirstName = userInfoDTO.FirstName;
            LastName = userInfoDTO.LastName;
        }

        public void Save()
        {
            _userInfoService.Save(new UserInfoDTO
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            });
        }

        public void Destroy()
        {
            FirstName = null;
            LastName = null;
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
