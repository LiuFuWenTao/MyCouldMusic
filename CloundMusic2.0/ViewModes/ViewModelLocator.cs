using CloundMusic2._0.Core;
using CloundMusic2._0.SystemDefinitions;
using CloundMusic2._0.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.ViewModes
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(()=>SimpleIoc.Default);

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();


            //创建导航服务
            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        #region VM业务逻辑VM
        public HomeViewModel HomeViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<HomeViewModel>();
            }
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainWindowViewModel>(); }
        }

        #endregion

        /// <summary>
        ///创建导航服务
        /// </summary>
        /// <returns></returns>
        private INavigationService CreateNavigationService()
        {
            
            var navigationService = new NavigationService();
            //框架页
            navigationService.Configure(ViewNames.MAINWINDOWS, new Uri("/MainWindow.xaml", UriKind.RelativeOrAbsolute));
            navigationService.Configure(ViewNames.HOMEPAGE, new Uri("/Views/HomePage.xaml", UriKind.RelativeOrAbsolute));
            return navigationService;
        }
    }
}
