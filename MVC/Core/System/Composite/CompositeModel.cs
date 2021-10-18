using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVC.Components.Composite
{
    public class CompositeModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
