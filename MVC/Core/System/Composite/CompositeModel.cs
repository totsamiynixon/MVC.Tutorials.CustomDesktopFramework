using System.ComponentModel;

namespace MVC.Components.Composite
{
    public class CompositeModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
