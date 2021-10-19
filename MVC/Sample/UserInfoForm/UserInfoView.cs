using MVC.Components.Composite;
using MVC.Components.Panel;
using System;

namespace MVC.Sample.UserInfoForm
{
    public class UserInfoView : CompositeViewBase<UserInfoModel>, IControllableView<UserInfoModel>
    {
        public IController<UserInfoModel> Controller { get; }

        public override int Height { get; set; } = 200;
        public override int Width { get; set; } = 200;

        public UserInfoView(UserInfoModel model, IController<UserInfoModel> controller, PanelView panelView) : base(model)
        {
            Controller = controller;
            AddSubView(panelView, 0, 0);
        }
    }
}
