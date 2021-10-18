using MVC.Components.Label;
using MVC.Components.TextInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVC.Sample
{
    public class SampleFormModel : IModel
    {
        public SampleFormModel(TextInputModel firstNameInput, TextInputModel lastNameInput, LabelModel labelModel)
        {
            FirstNameInput = firstNameInput;
            LastNameInput = lastNameInput;
            LabelModel = labelModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void SubmitHandler(object sender);

        public event SubmitHandler Submit;

        private LabelModel LabelModel { get; set; }

        private TextInputModel FirstNameInput { get; set; }

        private TextInputModel LastNameInput { get; set; }

        public void Initialize()
        {
            FirstNameInput.PropertyChanged += OnFirstNameChange;
            LastNameInput.PropertyChanged += OnLastNameChange;
            LabelModel.Text = FirstNameInput.Value + " " + LastNameInput.Value;
        }

        public void Destroy()
        {
            FirstNameInput.PropertyChanged -= OnFirstNameChange;
            LastNameInput.PropertyChanged -= OnLastNameChange;
        }

        private void OnFirstNameChange(object sender, PropertyChangedEventArgs args)
        {
            LabelModel.Text = FirstNameInput.Value + " " + LastNameInput.Value;
        }

        private void OnLastNameChange(object sender, PropertyChangedEventArgs args)
        {
            LabelModel.Text = FirstNameInput.Value + " " + LastNameInput.Value;
        }
    }
}
