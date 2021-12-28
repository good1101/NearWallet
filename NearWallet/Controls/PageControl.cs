using System;
using System.Windows.Controls;

namespace NearWallet.Controls
{
    public class PageControl : UserControl
    {
        public bool IsNavigate { get; set; }
        private Action _actionBack;
        public void SetBack(Action actionBack)
        {
            Grid grid = Content as Grid;
            if (grid == null)
                return;
            _actionBack = actionBack;
            PageNavigate pageNavigate = new PageNavigate(actionBack);
            grid.Children.Add(pageNavigate);
        }

        protected void Back()
        {
            _actionBack?.Invoke();
        }

        public virtual void Visible()
        {
            
        }
    }
}
