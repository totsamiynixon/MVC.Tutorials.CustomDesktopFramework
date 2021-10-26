using MVC.Core;
using MVC.Core.System.Control;
using System;

namespace MVC.Components.Button
{
    public class ButtonController : IController<ButtonModel>
    {
        public ButtonModel Model { get; protected set; }

        public ButtonController(ButtonModel model)
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

                if (keyboardControlContext.KeyInfo.Key == ConsoleKey.Enter)
                {
                    Model.TriggerSubmit();
                    controlContext.Handled = true;
                    return;
                }
            }
        }
    }
}
