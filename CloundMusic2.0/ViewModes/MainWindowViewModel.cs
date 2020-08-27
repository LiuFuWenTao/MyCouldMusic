using CloundMusic2._0.Base;
using CloundMusic2._0.Helper;
using CloundMusic2._0.Manager;
using CloundMusic2._0.SystemDefinitions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
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
        /// <summary>
        /// 导航服务类
        /// </summary>
        private INavigationService navigationService;
        #endregion
        #region 构造器
        public MainWindowViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            InitMessenger();
        }
        #endregion
        #region 保护变量
        #endregion

        #region 视图属性
        private string _searchKeyWord = string.Empty;
        /// <summary>
        /// 搜索音乐的关键字
        /// </summary>
        public string SearchKeyWord { get { return _searchKeyWord; }set { Set(() => SearchKeyWord, ref _searchKeyWord, value); } }

        private string _currentMusicUrl;
        /// <summary>
        /// 当前播放的音乐的地址
        /// </summary>
        public string CurrentMusicUrl { get { return _currentMusicUrl; } set { Set(() => CurrentMusicUrl, ref _currentMusicUrl, value); } }
        #endregion


        #region Commands
        private ICommand searchCommand;
        /// <summary>
        /// 通过关键字搜索音乐
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new RelayCommand(() =>
                    {
                        SearchMusic();
                    });
                }
                return this.searchCommand;
            }
            private set { }
        }
        #endregion

        #region 核心方法
        /// <summary>
        /// 通过关键字搜索音乐
        /// </summary>
        public void SearchMusic()
        {
            Logger.Log($"开始搜索音乐，音乐的关键字是{SearchKeyWord}");
            if(string.IsNullOrEmpty(SearchKeyWord))
            {
                return;
            }
            SimpleIoc.Default.GetInstance<HomeViewModel>()._keyWord = SearchKeyWord;
            this.navigationService.NavigateTo(ViewNames.HOMEPAGE);
        }
        #endregion


        #region 抽象方法
        /// <summary>
        /// 初始化界面
        /// </summary>
        protected override void InitViewModel()
        {
        }
        /// <summary>
        /// 卸载界面
        /// </summary>
        protected override void ResetViewModel()
        {
            
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 初始化Messenger方法
        /// 先全部放这，之后考虑是否抽取到单独的类中
        /// </summary>
        private void InitMessenger()
        {
            Messenger.Default.Register<string>(this, "_CurrentMusicUrl", (e) =>
            {
                //把传过来的音乐地址放置到播放器中
                CurrentMusicUrl = e;
            });
        }

        #endregion
    }
}
