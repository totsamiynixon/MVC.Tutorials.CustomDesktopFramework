using System.ComponentModel;

namespace MVC.Core.System.Composite
{
    public class CompositeModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
