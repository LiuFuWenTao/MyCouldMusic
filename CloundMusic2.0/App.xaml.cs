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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bool ret;
            mutex = new System.Threading.Mutex(true, "ElectronicNeedleTherapySystem", out ret);
            if (!ret)
            {
                //MessageBox.Show("系统正在运行，请勿重复打开");
                Environment.Exit(0);
            }
            //this.DispatcherUnhandledException += App_DispatcherUnhandledException;//ui线程意外错误捕获处理
            //this.RegisterEvents();//加强全局意外异常捕获
            //AppCoreManager.AppStart();//启动程序
        }
    }
}
