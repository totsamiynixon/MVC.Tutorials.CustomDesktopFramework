using System.Collections.Generic;

namespace MVC.Core
{
    public interface ICompositeView<out TModel> : IView<TModel> where TModel : IModel
    {
        public LinkedList<IView<IModel>> Children { get; }
    }
}
