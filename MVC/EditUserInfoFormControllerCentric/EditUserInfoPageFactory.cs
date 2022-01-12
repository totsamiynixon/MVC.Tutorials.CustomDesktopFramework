using MVC.Components.Button;
using MVC.Components.Form;
using MVC.Components.Label;
using MVC.Components.Panel;
using MVC.Components.TextInput;
using MVC.EditUserInfoFormControllerCentric.Application;
using MVC.EditUserInfoFormControllerCentric.Domain;

namespace MVC.EditUserInfoFormControllerCentric
{
    public static class EditUserInfoPageFactory
    {
        public static EditUserInfoPageView Create()
        {
            var panelView = CreatePanelView();
            var titleLabel = CreateLabelView("USER INFO FORM");
            var descriptionLabel = CreateLabelView("Press CTRL + SHIFT + S to save.");
            var formView = CreateFormView();
            var resultLabel = CreateLabelView(string.Empty);

            panelView.AddSubView(titleLabel);
            panelView.AddSubView(descriptionLabel, 0);
            panelView.AddSubView(formView);
            panelView.AddSubView(resultLabel, 5);

            var userInfoModel = new EditUserInfoPageModel(new UserInfoService());
            var userInfoController = new EditUserInfoPageController(userInfoModel, formView.Model, resultLabel.Model);
            var userInfoView = new EditUserInfoPageView(userInfoModel, userInfoController, panelView);

            return userInfoView;
        }

        private static PanelView CreatePanelView()
        {
            var panelView = new PanelView();
            panelView.Height = 32;

            return panelView;
        }

        private static FormView CreateFormView()
        {
            var firstNameInput = CreateInputView();
            var lastNameInput = CreateInputView();
            var submitButton = CreateButtonView("Submit");

            var formModel = new FormModel();
            var formController = new FormController(formModel);
            formController.AddInput(nameof(EditUserInfoPageModel.FirstName), firstNameInput.Model);
            formController.AddInput(nameof(EditUserInfoPageModel.LastName), lastNameInput.Model);
            formController.SetSubmitButton(submitButton.Model);

            var formView = new FormView(formModel, formController);
            formView.AddInput(firstNameInput);
            formView.AddInput(lastNameInput);
            formView.AddSubmitButton(submitButton);
            formView.Height = 20;

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
