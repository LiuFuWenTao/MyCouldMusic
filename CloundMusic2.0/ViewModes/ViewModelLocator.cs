using CloundMusic2._0.Core;
using CloundMusic2._0.SystemDefinitions;
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
            SimpleIoc.Default.Register<CommunalVariable>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<I>
        }

        #region VM业务逻辑VM
        public CommunalVariable CommunalVariable
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CommunalVariable>();
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
            navigationService.Configure(ViewNames.MAIN_WINDOWS, new Uri("/MainWindow.xaml", UriKind.RelativeOrAbsolute));
            return navigationService;
        }
    }
}
