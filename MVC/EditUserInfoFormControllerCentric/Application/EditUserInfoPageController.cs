using MVC.Components.Form;
using MVC.Components.Label;
using MVC.Core;
using MVC.Core.System.Control;
using System;
using System.ComponentModel;

namespace MVC.EditUserInfoFormControllerCentric.Application
{
    public class EditUserInfoPageController : IInitializableController<EditUserInfoPageModel>
    {
        public EditUserInfoPageModel Model { get; protected set; }
        public FormModel FormModel { get; }
        public LabelModel LabelModel { get; }

        public EditUserInfoPageController(EditUserInfoPageModel model, FormModel formModel, LabelModel labelModel)
        {
            Model = model;
            FormModel = formModel;
            LabelModel = labelModel;
        }

        public void Initialize()
        {
            Model.PropertyChanged += OnModelPropertyChanged;
            FormModel.PropertyChanged += OnFormModelPropertyChanged;
            FormModel.OnSubmit += OnFormSubmit;

            Model.Initialize();
        }

        public void HandleControl(IControlContext context)
        {
            if (context is KeyboardControlContext keyboardControlContext)
            {
                if (keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control)
                    && keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift)
                    && keyboardControlContext.KeyInfo.Key == ConsoleKey.S)
                {
                    Save();
                    context.Handled = true;
                }
            }
        }

        public void Destroy()
        {

            Model.PropertyChanged -= OnModelPropertyChanged;
            FormModel.PropertyChanged -= OnFormModelPropertyChanged;
            FormModel.OnSubmit -= OnFormSubmit;

            Model.Destroy();
        }

        protected void OnModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(Model.FirstName))
            {
                FormModel.SetPropertyValue(nameof(Model.FirstName), Model.FirstName);
            }

            if (args.PropertyName == nameof(EditUserInfoPageModel.LastName))
            {
                FormModel.SetPropertyValue(nameof(Model.LastName), Model.LastName);
            }
        }


        protected void OnFormModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(FormModel.Fields))
            {
                Model.FirstName = FormModel.Fields[nameof(Model.FirstName)];
                Model.LastName = FormModel.Fields[nameof(Model.LastName)];
            }
        }

        protected void OnFormSubmit(object sender)
        {
            Save();
        }

        protected void Save()
        {
            LabelModel.Text = "Result: " + string.Join(", ", Model.FirstName, Model.LastName);
            Model.Save();
        }
    }
}
