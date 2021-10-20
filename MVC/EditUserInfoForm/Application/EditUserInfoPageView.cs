﻿using MVC.Components.Panel;
using MVC.Core.System.Composite;

namespace MVC.EditUserInfoForm.Application
{
    public class EditUserInfoPageView : CompositeViewBase<EditUserInfoPageModel>, IControllableView<EditUserInfoPageModel>
    {
        public IController<EditUserInfoPageModel> Controller { get; }

        public override int Height { get; set; } = 200;
        public override int Width { get; set; } = 200;

        public EditUserInfoPageView(EditUserInfoPageModel model, IController<EditUserInfoPageModel> controller, PanelView panelView) : base(model)
        {
            Controller = controller;
            AddSubView(panelView, 0, 0);
        }
    }
}