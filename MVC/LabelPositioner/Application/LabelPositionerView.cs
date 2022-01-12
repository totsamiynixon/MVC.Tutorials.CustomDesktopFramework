using MVC.Components.Label;
using MVC.Components.TextInput;
using MVC.Core.System.Composite;
using System.ComponentModel;

namespace MVC.LabelPositioner.Application
{
    public class LabelPositionerView : CompositeViewBase<LabelPositionerModel>
    {
        public LabelView LabelView { get; set; }

        public LabelView TextInputView_X_Label { get; set; }

        public TextInputView TextInputView_X { get; set; }

        public LabelView TextInputView_Y_Label { get; set; }

        public TextInputView TextInputView_Y { get; set ; }

        public LabelPositionerView(LabelPositionerModel model) : base(model, null)
        {
            Controller = new LabelPositionerController(model, this);
        }

        public override void Initialize()
        {
            AddSubView(LabelView, 50, 20);

            AddSubView(TextInputView_X_Label, 2, 2);
            AddSubView(TextInputView_X, 2, 4);
            AddSubView(TextInputView_Y_Label, 60, 2);
            AddSubView(TextInputView_Y, 60, 4);

            base.Initialize();
        }

        protected override void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LabelView.OffsetX = Model.LabelPosition.X;
            LabelView.OffsetY = Model.LabelPosition.Y;

            base.ModelPropertyChanged(sender, e);
        }
    }
}
