using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVC.Core.System
{
    public class NoModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
