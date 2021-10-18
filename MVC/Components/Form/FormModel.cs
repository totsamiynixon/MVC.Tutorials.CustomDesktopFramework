using MVC.Components.Button;
using MVC.Components.TextInput;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MVC.Components.Form
{
    public class FormModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public delegate void OnSubmitHandler(object sender);


        public event OnSubmitHandler OnSubmit;

        private Dictionary<string, TextInputModel> Properties { get; set; } = new Dictionary<string, TextInputModel>();

        private Dictionary<string, PropertyChangedEventHandler> PropertyChangedEventHandlers { get; set; } = new Dictionary<string, PropertyChangedEventHandler>();

        private ButtonModel SubmitButton { get; set; }

        public void Initialize()
        {
            SubmitButton.OnSubmit += OnButtonSubmitted;

            foreach (var property in Properties)
            {
                PropertyChangedEventHandlers.Add(property.Key, (sender, args) =>
                {
                    if (args.PropertyName == nameof(TextInputModel.Value))
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(property.Key));
                    }
                });

                property.Value.PropertyChanged += PropertyChangedEventHandlers[property.Key];
            }
        }

        public void AddInput(string name, TextInputModel model)
        {
            Properties.Add(name, model);
        }

        public void SetSubmitButton(ButtonModel button)
        {
            SubmitButton = button;
        }

        public Dictionary<string, string> GetState()
        {
            return Properties.ToDictionary(x => x.Key, x => x.Value.Value);
        }

        public void Destroy()
        {
            SubmitButton.OnSubmit -= OnButtonSubmitted;

            foreach (var property in Properties)
            {
                property.Value.PropertyChanged -= PropertyChangedEventHandlers[property.Key];
            }
        }

        private void OnButtonSubmitted(object sender)
        {
            OnSubmit?.Invoke(this);
        }

    }
}
