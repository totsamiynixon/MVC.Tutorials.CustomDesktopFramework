using System.ComponentModel;

namespace MVC.Components.Label
{
    public class LabelModel : IModel
    {
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public LabelModel(string text)
        {
            this._text = text;
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.Equals(value, _text)) return;

                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
