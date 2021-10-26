using MVC.Core;
using System;
using System.ComponentModel;
using System.Linq;

namespace MVC.Components.Button
{
    public class ButtonView : ViewBase<ButtonModel>, IFocusableView<ButtonModel>
    {
        public ButtonView(ButtonModel model) : base(model, new ButtonController(model))
        {

        }

        public ButtonView(ButtonModel model, ButtonController controller) : base(model, controller)
        {
           
        }

        public override int Height { get; set; } = 4;
        public override int Width { get; set; } = 20;

        public void OnFocusIn()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Render();
            Console.ResetColor();
        }

        public void OnFocusOut()
        {
            Console.ResetColor();
            Render();
        }

        protected override void Render()
        {
            string horizontalLine = $"{string.Concat(Enumerable.Repeat('o', Width))}";
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

            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write(Model.Text);

            base.Render();
        }

        private void HandleModelPropertyChange(object sender, PropertyChangedEventArgs args)
        {
            Render();
        }
    }
}
