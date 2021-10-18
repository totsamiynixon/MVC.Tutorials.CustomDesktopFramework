using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC
{

    public class SystemController : ControllerBase<NoModel>
    {
        public ICompositeView<IModel> RootView { get; set; }

        public IView<IModel> CurrentView { get; set; }

        public SystemController(NoModel model) : base(model)
        {
        }

        public override void HandleControl(ControlEvent controlEvent)
        {
            TryHandleControl(CurrentView, controlEvent);

            if (controlEvent.Handled)
            {
                return;
            }

            controlEvent.Handled = true;


            if (controlEvent.Type == EventType.Keyboard)
            {
                if (CurrentView is IFocusableView<IModel> focusableView)
                {
                    focusableView.OnFocusOut();
                }

                if (controlEvent.Type == EventType.Keyboard && controlEvent.Payload is ConsoleKeyInfo keyInfo)
                {
                    if (keyInfo.Key == ConsoleKey.Spacebar && keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                    {
                        if (CurrentView is ICompositeView<IModel> compositeView)
                        {
                            CurrentView = compositeView.Children.OfType<IFocusableView<IModel>>().First();
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Tab && keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control | ConsoleModifiers.Shift))
                    {
                        CurrentView = CurrentView.Parent;

                        if (CurrentView == null)
                        {
                            CurrentView = RootView;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Tab && keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                    {
                        if (CurrentView.Parent is ICompositeView<IModel> parentCompositeView)
                        {
                            var currentViewNode = parentCompositeView.Children.Find(CurrentView);
                            CurrentView = GetFirstFocusableView(currentViewNode) ?? parentCompositeView.Children.OfType<IFocusableView<IModel>>().First();
                        }

                    }
                }

                if (CurrentView is IFocusableView<IModel> newFocusableView)
                {
                    newFocusableView.OnFocusIn();
                }
            }
        }

        public void Initialize()
        {
            ControlDriver.OnControl += HandleDriverControl;

            CurrentView = RootView;
            CurrentView.Initialize();

            if (CurrentView is IFocusableView<IModel> focusableView)
            {
                focusableView.OnFocusIn();
            }
        }

        public void Destroy()
        {
            ControlDriver.OnControl -= HandleDriverControl;

            RootView.Destroy();
        }

        private void HandleDriverControl(ControlEvent controlEvent)
        {
            this.HandleControl(controlEvent);
        }

        private void TryHandleControl(IView<IModel> view, ControlEvent controlEvent)
        {
            view.Controller.HandleControl(controlEvent);

            if (controlEvent.Handled == false)
            {
                if (view.Parent != null)
                {
                    TryHandleControl(view.Parent, controlEvent);
                }
            }
        }

        private IView<IModel> GetFirstFocusableView(LinkedListNode<IView<IModel>> node)
        {
            if(node.Next == null)
            {
                return null;
            }

            if(node.Next.Value is IFocusableView<IModel>)
            {
                return node.Next.Value;
            }

            return GetFirstFocusableView(node.Next);
        }
    }
}
