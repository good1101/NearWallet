using NearWallet.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NearWallet.Controls.Ext
{
    public class Navigation
    {
        public Navigation(Action<UserControl> actionSet, UserControl startPage = null)
        {
            _actionSet = actionSet;
            StartPage = startPage;
        }
        private readonly Action<UserControl> _actionSet;
        private readonly List<UserControl> _pages = new List<UserControl>();
        private UserControl _currentPage;
        private UserControl _lastPage;
        public UserControl CurrentPage => _currentPage;
        public UserControl StartPage { get;private set; }

        public void SetStartPage()
        {
            SetPage(StartPage);
        }

        public void SetPage(UserControl page)
        {
            page.Width = double.NaN;
            page.Height = double.NaN;
            int ind = _pages.IndexOf(_currentPage);
            if (ind != -1 && ind != _pages.Count -1)
                _pages.RemoveRange(ind + 1, _pages.Count - ind - 1 );
            _pages.Add(page);
            Set(page);
        }

        public void Back()
        {
            int ind = _pages.IndexOf(_currentPage) - 1;
            if (ind < 0 || ind >= _pages.Count)
                return;
            Set(_pages[ind]);
        }

        public void Next()
        {
            int ind = _pages.IndexOf(_currentPage) + 1;
            if (ind >= _pages.Count)
                return;
            Set(_pages[ind]);
        }

        public void UpdateCurrentPage()
        {
            (_currentPage as PageControl)?.Visible();
        }

        void Set(UserControl control)
        {
            if ( control is PageControl)
            {
                PageControl pc = control as PageControl;
                pc.Visible();
                if (pc.IsNavigate)
                    pc.SetBack(Back);
            }
            _lastPage = _currentPage;
            _currentPage = control;
            _actionSet(control);
        }

    }
}
