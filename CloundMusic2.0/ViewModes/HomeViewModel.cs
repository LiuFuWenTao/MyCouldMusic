using CloundMusic2._0.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CloundMusic2._0.ViewModes
{
    /// <summary>
    /// 描述：主页的业面VM
    /// 作者：liufuwentao
    /// 时间：2020/8/19 16:25:18
    /// </summary>
    public class HomeViewModel : CloundViewModelBase
    {
        #region 成员变量
        public string _keyWord;
        private IMusicManager musicManager;
        #endregion
        #region 视图属性

        private Song[] _songs;
        /// <summary>
        /// 歌曲列表
        /// </summary>
        public Song[] Songs { get { return this._songs; } set { Set(() => Songs, ref _songs, value); } }

        private Song _selectedSong;
        /// <summary>
        /// 用户选中的歌曲
        /// </summary>
        public Song SelectedSong { get { return this._selectedSong; } set { Set(() => SelectedSong, ref _selectedSong, value); } }
        #endregion

        #region Command
        public ICommand PlaySelectedSongCommand => new RelayCommand(PlaySelectSong);
        #endregion

        #region 核心方法
        private void PlaySelectSong()
        {
            //传入音乐地址给播放器
            var s = musicManager.GetSongUrl(SelectedSong.Id);
            Messenger.Default.Send(s, "_CurrentMusicUrl");
        }

        #endregion

        protected override void InitViewModel()
        {
            musicManager = MusicManagerFactory.Bulid();
            //进来之前做过为空过滤了，后续的不在这过滤
            Songs = musicManager.SearchMusic(_keyWord);
        }

        protected override void ResetViewModel()
        {
            _keyWord = string.Empty;
        }
    }
}
