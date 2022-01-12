using MVC.EditUserInfoFormControllerCentric.Domain;
using System.ComponentModel;

namespace MVC.LabelPositioner.Application
{
    public struct LabelPosition
    {
        public int X { get; set; }

        public int Y { get; set; }
    }

    public class LabelPositionerModel : IModel
    {
        private LabelPosition _labelPosition;

        public event PropertyChangedEventHandler PropertyChanged;

        public LabelPosition LabelPosition
        {
            get { return _labelPosition; }
            set
            {
                if (string.Equals(value, _labelPosition)) return;

                _labelPosition = value;
                OnPropertyChanged(nameof(LabelPosition));

            }
        }

        public void Save()
        {
            // some business logic goes here
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
