using MVC.Components.Button;
using MVC.Components.Form;
using MVC.Components.Label;
using MVC.Components.Panel;
using MVC.Components.TextInput;
using MVC.Controllers;

namespace MVC.Sample
{
    public class UserInfoForm
    {
        private readonly FormView _formView;
        private readonly LabelView _labelView;
        private readonly PanelView _panelView;
        public UserInfoForm()
        {
            var panelView = CreatePanelView();
            var formView = CreateFormView();
            var labelView = CreateLabelView();

            panelView.AddSubView(formView);
            panelView.AddSubView(labelView);

            _formView = formView;
            _labelView = labelView;
            _panelView = panelView;
        }

        public ICompositeView<IModel> View => _panelView;

        public void Initialize()
        {
            _formView.Model.Initialize();
            _formView.Model.OnSubmit += HandleFormSubmit;
        }

        public void Destroy()
        {
            _formView.Model.OnSubmit -= HandleFormSubmit;
            _formView.Model.Destroy();
        }

        private void HandleFormSubmit(object sender)
        {
            _labelView.Model.Text = string.Join(", ", _formView.Model.GetState().Values);

            // Domain interaction here
            // For example - http request
        }

        private static PanelView CreatePanelView()
        {
            var panelModel = new PanelModel();
            var panelController = new NoController<PanelModel>(panelModel);
            var panelView = new PanelView(panelModel, panelController);

            return panelView;
        }

        private static FormView CreateFormView()
        {
            var firstNameInput = CreateInputView();
            var lastNameInput = CreateInputView();
            var submitButton = CreateButtonView("Submit");

            var formModel = new FormModel();
            formModel.AddInput("firstName", firstNameInput.Model);
            formModel.AddInput("lastName", lastNameInput.Model);
            formModel.SetSubmitButton(submitButton.Model);

            var formView = new FormView(formModel, new NoController<FormModel>(formModel));
            formView.AddInput(firstNameInput);
            formView.AddInput(lastNameInput);
            formView.AddSubmitButton(submitButton);

            firstNameInput.Model.Value = "Yauheni";
            lastNameInput.Model.Value = "But-Husaim";

            return formView;
        }

        private static TextInputView CreateInputView()
        {
            var inputModel = new TextInputModel(string.Empty);
            var inputController = new TextInputController(inputModel);
            var inputView = new TextInputView(inputModel, inputController);

            return inputView;
        }

        private static ButtonView CreateButtonView(string text)
        {
            var buttonModel = new ButtonModel(text);
            var buttonController = new ButtonController(buttonModel);
            var buttonView = new ButtonView(buttonModel, buttonController);

            return buttonView;
        }

        private static LabelView CreateLabelView()
        {
            var labelModel = new LabelModel(string.Empty);
            var labelView = new LabelView(labelModel, new NoController<LabelModel>(labelModel));

            return labelView;
        }
    }
}
