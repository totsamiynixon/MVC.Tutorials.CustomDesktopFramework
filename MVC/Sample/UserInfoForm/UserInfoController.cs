using MVC.Components.Form;
using MVC.Components.Label;
using MVC.Core;
using MVC.Core.System.Control;
using System;
using System.ComponentModel;

namespace MVC.Sample.UserInfoForm
{
    public class UserInfoController : IInitializableController<UserInfoModel>, IControlHandlingController<UserInfoModel>
    {
        public UserInfoModel Model { get; protected set; }
        public FormModel Form { get; }
        public LabelModel Label { get; }

        public UserInfoController(UserInfoModel model, FormModel form, LabelModel label)
        {
            Model = model;
            Form = form;
            Label = label;
        }

        public void Initialize()
        {
            Form.PropertyChanged += OnFormPropertyChanged;
            Form.OnSubmit += OnFormSubmit;
        }

        public void HandleControl(IControlContext context)
        {
            if(context is KeyboardControlContext keyboardControlContext)
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
            Form.PropertyChanged -= OnFormPropertyChanged;
            Form.OnSubmit -= OnFormSubmit;
        }


        protected void OnFormPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(FormModel.Fields))
            {
                Model.FirstName = Form.Fields[nameof(UserInfoModel.FirstName)];
                Model.LastName = Form.Fields[nameof(UserInfoModel.LastName)];
            }
        }

        protected void OnFormSubmit(object sender)
        {
            Save();
        }

        protected void Save()
        {
            Label.Text = "Result: " + string.Join(", ", Model.FirstName, Model.LastName);
            Model.Save();
        }
    }
}
