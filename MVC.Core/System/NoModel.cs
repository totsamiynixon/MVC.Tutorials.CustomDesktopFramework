using System.ComponentModel;

namespace MVC.Core.System
{
    public class NoModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
