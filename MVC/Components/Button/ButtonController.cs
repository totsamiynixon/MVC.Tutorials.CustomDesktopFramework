using System;

namespace MVC.Components.Button
{
    public class ButtonController : ControllerBase<ButtonModel>
    {

        public ButtonController(ButtonModel model) : base(model)
        {
        }


        public override void HandleControl(ControlEvent controlEvent)
        {
            if (controlEvent.Type == EventType.Keyboard && controlEvent.Payload is ConsoleKeyInfo keyInfo)
            {
                if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    return;
                }

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Model.TriggerSubmit();
                    controlEvent.Handled = true;
                    return;
                }
            }
        }
    }
}
