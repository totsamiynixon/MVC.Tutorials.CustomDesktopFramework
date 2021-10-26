using MVC.Core;
using System;
using System.ComponentModel;
using System.Linq;

namespace MVC.Components.TextInput
{
    public class TextInputView : ViewBase<TextInputModel>, IFocusableView<TextInputModel>
    {
        public TextInputView(TextInputModel model) : base(model, new TextInputController(model)) { }
        public TextInputView(TextInputModel model, TextInputController controller) : base(model, controller) { }

        public override int Height { get; set; } = 4;

        public override int Width { get; set; } = 50;

        public void OnFocusIn()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(X + 2 + Model.Value.Length, Y + 2);
        }

        public void OnFocusOut()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        protected override void Render()
        {
            string horizontalLine = $"{string.Concat(Enumerable.Repeat('*', Width))}";
            string verticalLine = $"*{string.Concat(Enumerable.Repeat(' ', Width - 2))}*";

            Console.SetCursorPosition(X, Y);
            Console.Write(horizontalLine);
            for (int i = 1; i < Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(string.Concat(verticalLine));
            }
            Console.SetCursorPosition(X, Y + Height);
            Console.Write(horizontalLine);

            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write(Model.Value);
        }

        protected override void PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Render();
        }

    }
}
