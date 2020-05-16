using CloundMusic2._0.Helper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CloundMusic2._0.Core
{
    /// <summary>
    /// 导航跳转类
    /// </summary>
    public class NavigationService : ViewModelBase,INavigationService
    {
        #region 成员变量
        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly Dictionary<string, Page> _pageInstancesByKey;
        private readonly List<string> _historic;
        private bool _isNavigating;//是否正在导航
        private string _currentPageKey;
        /// <summary>
        /// 当前框架容器
        /// </summary>
        private Frame currentFrame = null;
        #endregion

        #region Properties
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref _currentPageKey, value);
            }
        }
        public object Parameter { get; private set; }
        #endregion

        #region Ctors and Methods
        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _pageInstancesByKey = new Dictionary<string, Page>();
            _historic = new List<string>();
        }
        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);

                NavigateTo(_historic.Last(), "Back");
            }
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            if (_isNavigating)
            {
                return;
            }
            _isNavigating = true;
            try
            {
                lock (_pagesByKey)
                {
                    if (!_pagesByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                    }
                    if (this.currentFrame == null)
                    {
                        var frame = FindControlHelper.Instance.GetChildObject<Frame>(Application.Current.MainWindow, "MainFrame");
                        if (frame != null)
                        {
                            this.currentFrame = frame;
                            this.currentFrame.Navigated -= CurrentFrame_Navigated;
                            this.currentFrame.Navigated += CurrentFrame_Navigated;
                        }
                        else
                        {
                            throw new Exception("frame is null");
                        }
                    }
                    bool reloadPage = false;
                    if (parameter != null)
                    {
                        bool.TryParse(parameter.ToString(), out reloadPage);
                    }
                    if (this.currentFrame != null)
                    {
                        if (this._pageInstancesByKey.ContainsKey(pageKey) && reloadPage == false)
                        {
                            //LogManagers.Logger.Log(string.Format("导航至目标历史page：{0}，{1}......", pageKey, this._pageInstancesByKey[pageKey].Name));
                            this.currentFrame.NavigationService.Navigate(this._pageInstancesByKey[pageKey]);
                        }
                        else
                        {
                            this.currentFrame.Source = _pagesByKey[pageKey];
                            this._currentPageKey = pageKey;
                        }
                    }
                    Parameter = parameter;
                    if (parameter.ToString().Equals("Next"))
                    {
                        _historic.Add(pageKey);
                    }
                    CurrentPageKey = pageKey;
                }
            }
            finally
            {
                _isNavigating = false;
            }
        }
        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }
        #endregion

        #region 辅助方法
        private void CurrentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            //LogManagers.Logger.Log(string.Format("page：{0}，{1}已导航加载完毕！", this._currentPageKey, page?.Name));
            this.AddPageInstance(this._currentPageKey, page);
        }
        private void AddPageInstance(string key, Page instance)
        {
            lock (_pageInstancesByKey)
            {
                if (!_pageInstancesByKey.ContainsKey(key) && instance != null)
                {
                    if (this.Parameter == null)
                    {
                        _pageInstancesByKey.Add(key, instance);
                    }
                    else
                    {
                        bool reloadPage = false;
                        bool.TryParse(this.Parameter.ToString(), out reloadPage);
                        if (!reloadPage)
                        {
                            _pageInstancesByKey.Add(key, instance);
                        }
                    }
                }
            }
        }
        private FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
