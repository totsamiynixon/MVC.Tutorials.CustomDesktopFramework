using MVC.Core;
using MVC.Core.System.Control;
using System;

namespace MVC.Components.TextInput
{
    public class TextInputController : IController<TextInputModel>
    {
        public TextInputModel Model { get; protected set; }

        public TextInputController(TextInputModel model)
        {
            Model = model;
        }


        public void HandleControl(IControlContext controlContext)
        {
            if (controlContext is KeyboardControlContext keyboardControlContext)
            {
                if (keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    return;
                }

                if (keyboardControlContext.KeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (this.Model.Value.Length > 0)
                    {
                        this.Model.Value = this.Model.Value.Remove(this.Model.Value.Length - 1);
                    }

                    controlContext.Handled = true;

                    return;
                }

                this.Model.Value += keyboardControlContext.KeyInfo.KeyChar;
                controlContext.Handled = true;
            }
        }
    }
}
