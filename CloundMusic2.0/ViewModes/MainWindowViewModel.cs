using CloundMusic2._0.Base;
using CloundMusic2._0.Helper;
using CloundMusic2._0.Manager;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloundMusic2._0.ViewModes
{
    /// <summary>
    ///  主页vm
    ///  author ：lfwt
    /// </summary>
    public class MainWindowViewModel : CloundViewModelBase
    {
        #region 成员变量
        #endregion

        #region 保护变量
        #endregion

        #region 视图属性
        private string musicKeyWord = string.Empty;
        /// <summary>
        /// 搜索音乐的关键字
        /// </summary>
        public string MusicKeyWord
        {
            get { return this.musicKeyWord; }
            set
            {
                if(this.musicKeyWord != value)
                {
                    this.musicKeyWord = value;
                    base.RaisePropertyChanged("MusicKeyWord");
                }
            }
        }
        #endregion


        #region Commands
        private ICommand searchMusicCommand;
        /// <summary>
        /// 通过关键字搜索音乐
        /// </summary>
        public ICommand SearchMusicCommand
        {
            get
            {
                if (this.searchMusicCommand == null)
                {
                    this.searchMusicCommand = new RelayCommand(() =>
                    {
                        SearchMusic();
                    });
                }
                return this.searchMusicCommand;
            }
            private set { }
        }
        #endregion

        #region 核心方法
        /// <summary>
        /// 通过关键字搜索音乐
        /// </summary>
        public async void SearchMusic()
        {
            Logger.Log($"开始搜索音乐，音乐的关键字是{MusicKeyWord}");
            var reslut = await MusicManager.MusicApi.SearchMusic(MusicKeyWord);
        }
        #endregion


        #region 抽象方法
        /// <summary>
        /// 初始化界面
        /// </summary>
        protected override void InitViewModel()
        {
            //增加一个懂得测试
        }
        /// <summary>
        /// 卸载界面
        /// </summary>
        protected override void ResetViewModel()
        {
            
        }
        #endregion

        #region 辅助方法


        #endregion
    }
}
