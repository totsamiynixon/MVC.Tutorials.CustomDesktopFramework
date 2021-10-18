using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVC.Models
{
    public class NoModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
