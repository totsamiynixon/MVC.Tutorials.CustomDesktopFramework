using System;
using System.Text.RegularExpressions;

namespace MVC.Components.TextInput
{
    public class TextInputController : ControllerBase<TextInputModel>
    {

        private static Regex InputRegex = new Regex(@"^[A-Za-z]+$");

        public TextInputController(TextInputModel model) : base(model)
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

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (this.Model.Value.Length > 0)
                    {
                        this.Model.Value = this.Model.Value.Remove(this.Model.Value.Length - 1);
                    }

                    controlEvent.Handled = true;

                    return;
                }

                this.Model.Value += keyInfo.KeyChar;
                controlEvent.Handled = true;
            }
        }
    }
}
