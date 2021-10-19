using MVC.Components.Button;
using MVC.Components.Composite;
using MVC.Components.TextInput;
using System;
using System.ComponentModel;
using System.Linq;

namespace MVC.Components.Form
{
    public class FormView : CompositeViewBase<FormModel>, IControllableView<FormModel>
    {
        public IController<FormModel> Controller { get; }

        public FormView(FormModel model, IController<FormModel> controller) : base(model)
        {
            Controller = controller;
        }

        public override int Height { get; set; } = 30;

        public override int Width { get; set; } = 106;

        protected override void Render()
        {
            string horizontalLine = $"{string.Concat(Enumerable.Repeat('$', Width))}";
            string verticalLine = $"${string.Concat(Enumerable.Repeat(' ', Width - 2))}$";

            Console.SetCursorPosition(X, Y);
            Console.Write(horizontalLine);
            for (int i = 1; i < Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(string.Concat(verticalLine));

            }
            Console.SetCursorPosition(X, Y + Height);
            Console.Write(horizontalLine);

            base.Render();
        }

        public void AddInput(TextInputView view)
        {
            var lastEntry = ViewEntries.LastOrDefault();
            var yOffset = lastEntry.View == null ? 2 : lastEntry.Slot.Y + lastEntry.View.Height + 2;

            base.AddSubView(view, 2, yOffset);
        }

        public void AddSubmitButton(ButtonView view)
        {
            var lastEntry = ViewEntries.LastOrDefault();
            var yOffset = lastEntry.Slot.Y == 0 ? 2 : lastEntry.Slot.Y + 6;

            base.AddSubView(view, 2, yOffset);
        }

        protected override void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
    }
}
