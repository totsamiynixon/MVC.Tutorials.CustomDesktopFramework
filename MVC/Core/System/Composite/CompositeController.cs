using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Components.Composite
{
    public abstract class CompositeController<TModel> : ControllerBase<TModel> where TModel : IModel
    {
        protected CompositeController(TModel model) : base(model)
        {
        }
    }
}
