using MVC.Components.Composite;
using System;
using System.Linq;

namespace MVC.Components.Panel
{
    public class PanelView : CompositeView<PanelModel>
    {
        public PanelView(PanelModel model, IController<PanelModel> controller) : base(model, controller)
        {
        }

        public override int Height { get; set; } = 40;

        public override int Width { get; set; } = 115;

        protected override void Render()
        {
            string horizontalLine = $"{string.Concat(Enumerable.Repeat('-', Width))}";
            string verticalLine = $"-{string.Concat(Enumerable.Repeat(' ', Width - 2))}-";

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

        public void AddSubView<TView>(TView view) where TView : IView<IModel>
        {
            var lastEntry = ViewEntries.LastOrDefault();
            var yOffset = lastEntry.View == null ? 4 : lastEntry.Slot.Y + lastEntry.View.Height + 4;

            base.AddSubView(view, 4, yOffset);
        }

        public override void OnFocusIn()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Render();
            Console.ResetColor();
        }

        public override void OnFocusOut()
        {
            Render();
        }
    }
}
