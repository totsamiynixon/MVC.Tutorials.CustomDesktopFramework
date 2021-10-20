using System.ComponentModel;

namespace MVC.Components.TextInput
{
    public class TextInputModel: IModel
    {
        private string _value;

        public event PropertyChangedEventHandler PropertyChanged;

        public TextInputModel(string value)
        {
            this._value = value;
        }

        public string Value
        {
            get { return _value; }
            set
            {
                if (string.Equals(value, _value)) return;

                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
