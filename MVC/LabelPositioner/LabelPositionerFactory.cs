using MVC.Components.Button;
using MVC.Components.Label;
using MVC.Components.TextInput;
using MVC.LabelPositioner.Application;

namespace MVC.LabelPositioner
{
    public static class LabelPositionerFactory
    {
        public static LabelPositionerView Create()
        {
            var labelPositionerView = new LabelPositionerView(new LabelPositionerModel());
            labelPositionerView.LabelView = CreateLabelView("Move me");
            labelPositionerView.TextInputView_X_Label = CreateLabelView("Enter X");
            labelPositionerView.TextInputView_X = CreateInputView();
            labelPositionerView.TextInputView_Y_Label = CreateLabelView("Enter Y");
            labelPositionerView.TextInputView_Y = CreateInputView();

            return labelPositionerView;
        }

        private static TextInputView CreateInputView()
        {
            var inputModel = new TextInputModel(string.Empty);
            var inputController = new TextInputController(inputModel);
            var inputView = new TextInputView(inputModel, inputController);

            return inputView;
        }

        private static LabelView CreateLabelView(string text)
        {
            var labelModel = new LabelModel(text);
            var labelView = new LabelView(labelModel);

            return labelView;
        }
    }
}
