using MVC.Core;
using MVC.Core.System.Control;
using System;

namespace MVC.EditUserInfoFormModelCentric.Application
{
    public class EditUserInfoPageController : IInitializableController<EditUserInfoPageModel>
    {
        public EditUserInfoPageModel Model { get; protected set; }

        public EditUserInfoPageController(EditUserInfoPageModel model)
        {
            Model = model;
        }

        public void Initialize()
        {
            Model.FormModel.PropertyChanged += Model.FormModel_PropertyChanged;
            Model.FormModel.OnSubmit += Model.FormModel_OnSubmit;

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
                    Model.Save();
                    context.Handled = true;
                }
            }
        }

        public void Destroy()
        {

            Model.FormModel.PropertyChanged -= Model.FormModel_PropertyChanged;
            Model.FormModel.OnSubmit -= Model.FormModel_OnSubmit;

            Model.Destroy();
        }

    }
}
