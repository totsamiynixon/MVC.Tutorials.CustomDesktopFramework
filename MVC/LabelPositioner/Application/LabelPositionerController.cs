using MVC.Core;
using MVC.Core.System.Control;
using System;
using System.ComponentModel;

namespace MVC.LabelPositioner.Application
{

    public class LabelPositionerController : IController<LabelPositionerModel>
    {
        public LabelPositionerModel Model { get; protected set; }

        public LabelPositionerView View { get; protected set; }

        public LabelPositionerController(LabelPositionerModel model, LabelPositionerView view)
        {
            Model = model;
            View = view;
        }

        public void HandleControl(IControlContext context)
        {
            if (context is KeyboardControlContext keyboardControlContext)
            {
                if (keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control)
                    && keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift)
                    && keyboardControlContext.KeyInfo.Key == ConsoleKey.S)
                {
                    Model.LabelPosition = new LabelPosition
                    {
                        X = int.Parse(View.TextInputView_X.Model.Value),
                        Y = int.Parse(View.TextInputView_Y.Model.Value)
                    };

                    context.Handled = true;
                }
            }
        }

    }
}
