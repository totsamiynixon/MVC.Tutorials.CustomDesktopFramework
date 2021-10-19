using System.Collections.Generic;
using System.ComponentModel;

namespace MVC.Components.Form
{
    public class FormModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void OnSubmitHandler(object sender);

        public event OnSubmitHandler OnSubmit;

        private Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();


        public Dictionary<string, string> Fields => new Dictionary<string, string>(Properties);

        public void SetPropertyValue(string name, string value)
        {
            Properties[name] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fields)));
        }

        public void DispatchSubmit()
        {
            OnSubmit?.Invoke(this);
        }

    }
}
