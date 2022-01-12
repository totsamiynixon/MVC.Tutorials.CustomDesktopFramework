using MVC.Components.Form;
using MVC.Components.Label;
using MVC.EditUserInfoFormControllerCentric.Domain;
using System.ComponentModel;

namespace MVC.EditUserInfoFormModelCentric.Application
{
    public class EditUserInfoPageModel : IModel
    {
        private readonly UserInfoService _userInfoService;

        private string _firstName;
        private string _lastName;

        public FormModel FormModel { get; }
        public LabelModel LabelModel { get; }

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

            LabelModel.Text = "Result: " + string.Join(", ", FirstName, LastName);
        }

        public void Destroy()
        {
            FirstName = null;
            LastName = null;
        }

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == nameof(FirstName))
            {
                FormModel.SetPropertyValue(nameof(FirstName), FirstName);
            }

            if (propertyName == nameof(LastName))
            {
                FormModel.SetPropertyValue(nameof(LastName), LastName);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void FormModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(FormModel.Fields))
            {
                FirstName = FormModel.Fields[nameof(FirstName)];
                LastName = FormModel.Fields[nameof(LastName)];
            }
        }

        public virtual void FormModel_OnSubmit(object sender)
        {
            Save();
        }

    }
}
