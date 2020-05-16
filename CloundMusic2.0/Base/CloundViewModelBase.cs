using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloundMusic2._0.Base
{
    /// <summary>
    /// VM基类，父类只做公共的东西，而且子类尽量别重写父类的方法
    /// anthor:lfwt
    /// </summary>
    public abstract class CloundViewModelBase:ViewModelBase
    {
        #region 成员变量
        #endregion

        #region 保护变量
        #endregion

        #region 视图属性
        #endregion


        #region Commands

        private ICommand loadCommand;
        /// <summary>
        /// 界面加载后
        /// </summary>
        public ICommand LoadCommand
        {
            get
            {
                if (this.loadCommand == null)
                {
                    this.loadCommand = new RelayCommand(() =>
                    {
                        this.InitViewModel();
                    });
                }
                return this.loadCommand;
            }
            private set
            { }
        }
        private ICommand unLoadCommand;
        /// <summary>
        /// 界面卸载后
        /// </summary>
        public ICommand UnLoadCommand
        {
            get
            {
                if (this.unLoadCommand == null)
                {
                    this.unLoadCommand = new RelayCommand(() =>
                    {
                        this.ResetViewModel();
                    });
                }
                return this.unLoadCommand;
            }
            private set
            { }
        }
        #endregion

        #region 保护方法
        #endregion
        

        #region 抽象方法
        /// <summary>
        /// 初始化VM
        /// </summary>
        protected abstract void InitViewModel();
        /// <summary>
        /// 重置VM
        /// </summary>
        protected abstract void ResetViewModel();
        #endregion

        #region 辅助方法

       
        #endregion
    }
}
