using MVC.Components.Button;
using MVC.Components.TextInput;
using System.Collections.Generic;
using System.ComponentModel;

namespace MVC.Components.Form
{
    public class FormController : IInitializableController<FormModel>
    {
        public FormModel Model { get; }

        public ButtonModel SubmitButtonModel { get; private set; }

        private Dictionary<string, TextInputModel> PropertyModelMap { get; set; } = new Dictionary<string, TextInputModel>();

        private Dictionary<string, PropertyChangedEventHandler> PropertyChangedEventHandlers { get; set; } = new Dictionary<string, PropertyChangedEventHandler>();

        public FormController(FormModel model)
        {
            Model = model;
        }

        public void AddInput(string name, TextInputModel textInputModel)
        {
            PropertyModelMap.Add(name, textInputModel);
            Model.SetPropertyValue(name, textInputModel.Value);
        }

        public void SetSubmitButton(ButtonModel button)
        {
            SubmitButtonModel = button;
        }

        public void Initialize()
        {
            SubmitButtonModel.OnSubmit += OnSubmit;

            Model.PropertyChanged += OnModelPropertyChanged;

            foreach (var field in Model.Fields)
            {
                PropertyModelMap[field.Key].Value = field.Value;
            }

            foreach (var property in PropertyModelMap)
            {
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
            SubmitButtonModel.OnSubmit -= OnSubmit;

            Model.PropertyChanged -= OnModelPropertyChanged;

            foreach (var property in PropertyModelMap)
            {
                property.Value.PropertyChanged -= PropertyChangedEventHandlers[property.Key];
            }
        }

        protected void OnModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(FormModel.Fields))
            {
                foreach (var field in ((FormModel)sender).Fields)
                {
                    PropertyModelMap[field.Key].Value = field.Value;
                }
            }
        }

        protected virtual void OnSubmit(object sender)
        {
            Model.DispatchSubmit();
        }

    }
}
