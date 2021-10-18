using System.ComponentModel;

namespace MVC.Components.Button
{
    public class ButtonModel : IModel
    {
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void OnSubmitHandler(object sender);

        public event OnSubmitHandler OnSubmit;

        public ButtonModel(string text)
        {
            this._text = text;
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public void TriggerSubmit()
        {
            OnSubmit?.Invoke(this);
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
