using MVC.Core.System.Control;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Core.System
{
    public class SystemKeyboardControlHandler : ISystemControlHandler
    {
        public void HandleControl(SystemController systemController, IControlContext controlContext)
        {
            if (controlContext is KeyboardControlContext keyboardControlContext)
            {
                if (keyboardControlContext.KeyInfo.Key == ConsoleKey.Spacebar && keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    if (systemController.CurrentView is ICompositeView<IModel> compositeView)
                    {
                        systemController.CurrentView = GetFocusable(compositeView);

                        controlContext.Handled = true;
                    }
                }
                else if (keyboardControlContext.KeyInfo.Key == ConsoleKey.Tab && keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control | ConsoleModifiers.Shift))
                {
                    systemController.CurrentView = systemController.CurrentView.Parent;

                    if (systemController.CurrentView == null)
                    {
                        systemController.CurrentView = systemController.RootView;
                    }

                    controlContext.Handled = true;
                }
                else if (keyboardControlContext.KeyInfo.Key == ConsoleKey.Tab && keyboardControlContext.KeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    var currentViewNode = systemController.CurrentView.Parent.Children.Find(systemController.CurrentView);
                    systemController.CurrentView = GetFirstFocusableView(currentViewNode) ?? systemController.CurrentView.Parent.Children.OfType<IFocusableView<IModel>>().First();

                    controlContext.Handled = true;

                }
            }
        }

        private IFocusableView<IModel> GetFocusable(ICompositeView<IModel> compositeView)
        {
            foreach(var child in compositeView.Children)
            {
                if (child is IFocusableView<IModel> fosuableView)
                {
                    return fosuableView;
                }

                if (child is ICompositeView<IModel> childCompositeView)
                {
                    return GetFocusable(childCompositeView);
                }

            }

            return null;
        }


        private IView<IModel> GetFirstFocusableView(LinkedListNode<IView<IModel>> node)
        {
            if (node.Next == null)
            {
                return null;
            }

            if (node.Next.Value is IFocusableView<IModel>)
            {
                return node.Next.Value;
            }

            return GetFirstFocusableView(node.Next);
        }
    }
}
