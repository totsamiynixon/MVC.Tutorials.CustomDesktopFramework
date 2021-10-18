using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Controllers
{
    public class NoController<TModel> : ControllerBase<TModel> where TModel : IModel
    {
        public NoController(TModel model) : base(model)
        {
        }

        public override void HandleControl(ControlEvent controlEvent)
        {
           
        }
    }
}
