using System;

using System.Linq;

namespace MVC.Components.Label
{
    public class LabelView : ViewBase<LabelModel>
    {
        public LabelView(LabelModel model, IController<LabelModel> controller) : base(model, controller)
        {
           
        }

        public override int Height { get; set; } = 5;
        public override int Width { get; set; } = 20;

        protected override void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Width)));
            Console.SetCursorPosition(X, Y);
            Console.Write(Width < Model.Text.Length ? Model.Text.Substring(0, Width) : Model.Text);

            base.Render();
        }
    }
}
