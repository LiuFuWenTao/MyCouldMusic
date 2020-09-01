using CloundMusic2._0.Helper;
using Lierda.WPFHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CloundMusic2._0
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        System.Threading.Mutex mutex;
        LierdaCracker cracker = new LierdaCracker();
        protected override void OnStartup(StartupEventArgs e)
        {
            cracker.Cracker(100);//垃圾回收间隔时间
            base.OnStartup(e);
            bool ret;
            mutex = new System.Threading.Mutex(true, "ElectronicNeedleTherapySystem", out ret);
            if (!ret)
            {
                //MessageBox.Show("系统正在运行，请勿重复打开");
                Environment.Exit(0);
            }
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;//ui线程意外错误捕获处理
            this.RegisterEvents();//加强全局意外异常捕获
        }
        /// <summary>
        /// 处理全局意外异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Log("程序发生意外错误！！");
            Logger.LogError(e.Exception);
            e.Handled = true;//使得程序不能崩溃
        }
        private void RegisterEvents()
        {
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Logger.Log("全局事件捕获到意外线程错误！");
                Logger.LogError(args?.Exception);
                args.SetObserved();
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Logger.Log("AppDomain.CurrentDomain.UnhandledException！");
                if (args != null)
                {
                    string errorMsg = args.ExceptionObject == null ? "" : args.ExceptionObject.ToString();
                    Logger.Log("UnhandledException：" + errorMsg);
                }
            };
        }

    }
}
