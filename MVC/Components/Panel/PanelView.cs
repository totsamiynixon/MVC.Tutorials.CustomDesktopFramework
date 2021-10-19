using MVC.Components.Composite;
using MVC.Core.System;
using System;
using System.Linq;

namespace MVC.Components.Panel
{
    public class PanelView : CompositeViewBase<NoModel>, IFocusableView<NoModel>
    {
        public PanelView(NoModel model) : base(model)
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

        public void AddSubView<TView>(TView view, int marginTop = 2) where TView : IView<IModel>
        {
            var lastEntry = ViewEntries.LastOrDefault();
            var yOffset = lastEntry.View == null ? marginTop : lastEntry.Slot.Y + lastEntry.View.Height + marginTop;

            base.AddSubView(view, 4, yOffset);
        }

        public void OnFocusIn()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Render();
            Console.ResetColor();
        }

        public void OnFocusOut()
        {
            Render();
        }
    }
}
