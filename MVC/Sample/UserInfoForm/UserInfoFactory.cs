using MVC.Components.Button;
using MVC.Components.Form;
using MVC.Components.Label;
using MVC.Components.Panel;
using MVC.Components.TextInput;
using MVC.Core.System;

namespace MVC.Sample.UserInfoForm
{
    public static class UserInfoFactory
    {
        public static UserInfoView Create()
        {
            var panelView = CreatePanelView();
            var titleLabel = CreateLabelView("User info form");
            var descriptionLabel = CreateLabelView("Press CTRL + SHIFT + S to save progress");
            var formView = CreateFormView();
            var resultLabel = CreateLabelView(string.Empty);

            panelView.AddSubView(titleLabel);
            panelView.AddSubView(descriptionLabel, 0);
            panelView.AddSubView(formView);
            panelView.AddSubView(resultLabel);

            var userInfoModel = new UserInfoModel();
            var userInfoController = new UserInfoController(userInfoModel, formView.Model, resultLabel.Model);
            var userInfoView = new UserInfoView(userInfoModel, userInfoController, panelView);

            return userInfoView;
        }

        private static PanelView CreatePanelView()
        {
            var panelModel = new NoModel();
            var panelView = new PanelView(panelModel);

            return panelView;
        }

        private static FormView CreateFormView()
        {
            var firstNameInput = CreateInputView();
            var lastNameInput = CreateInputView();
            var submitButton = CreateButtonView("Submit");

            var formModel = new FormModel();
            var formController = new FormController(formModel);
            formController.AddInput(nameof(UserInfoModel.FirstName), firstNameInput.Model);
            formController.AddInput(nameof(UserInfoModel.LastName), lastNameInput.Model);
            formController.SetSubmitButton(submitButton.Model);

            var formView = new FormView(formModel, formController);
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

        private static LabelView CreateLabelView(string text)
        {
            var labelModel = new LabelModel(text);
            var labelView = new LabelView(labelModel);

            return labelView;
        }
    }
}
