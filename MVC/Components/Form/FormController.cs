using MVC.Components.Button;
using MVC.Components.TextInput;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVC.Components.Form
{
    public class FormController : IInitializableController<FormModel>
    {
        public FormModel Model { get; }

        public ButtonModel SubmitButton { get; private set; }

        private Dictionary<string, TextInputModel> PropertyModelMap { get; set; } = new Dictionary<string, TextInputModel>();

        private Dictionary<string, PropertyChangedEventHandler> PropertyChangedEventHandlers { get; set; } = new Dictionary<string, PropertyChangedEventHandler>();

        public FormController(FormModel model)
        {
            Model = model;
        }

        public void AddInput(string name, TextInputModel model)
        {
            PropertyModelMap.Add(name, model);
            Model.SetPropertyValue(name, model.Value);
        }

        public void SetSubmitButton(ButtonModel button)
        {
            SubmitButton = button;
        }

        public void Initialize()
        {
            SubmitButton.OnSubmit += OnSubmit;

            foreach (var property in PropertyModelMap)
            {
                Model.SetPropertyValue(property.Key, property.Value.Value);

                PropertyChangedEventHandlers.Add(property.Key, (sender, args) =>
                {
                    if (args.PropertyName == nameof(TextInputModel.Value))
                    {
                        Model.SetPropertyValue(property.Key, ((TextInputModel)sender).Value);
                    }
                });

                property.Value.PropertyChanged += PropertyChangedEventHandlers[property.Key];
            }
        }

        public void Destroy()
        {
            SubmitButton.OnSubmit -= OnSubmit;

            foreach (var property in PropertyModelMap)
            {
                property.Value.PropertyChanged -= PropertyChangedEventHandlers[property.Key];
            }
        }

        protected virtual void OnSubmit(object sender)
        {
            Model.DispatchSubmit();
        }

    }
}
