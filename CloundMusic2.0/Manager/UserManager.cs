using CloundMusic2._0.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 用户类，保存用户信息，允许用户执行相应的操作
    /// </summary>
    public class User
    {
        #region 属性

        
        private string _name;
        /// <summary>
        /// 用户名
        /// </summary>
        public string _Name
        {
            get { return this._name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                }
            }
        }

        private string _password;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string _Password
        {
            get { return this._password; }
            set
            {
                if (this._password != value)
                {
                    this._password = value;
                }
            }
        }

        private string _nickName;
        /// <summary>
        /// 昵称
        /// </summary>
        public string _NickName
        {
            get
            {
                return this._nickName;
            }
            set
            {
                if (this._nickName != value)
                {
                    this._nickName = value;
                }
            }
        }

        private List<MusicManager> _historyMusicList;
        /// <summary>
        /// 历史记录列表
        /// 
        /// </summary>
        public List<MusicManager> _HistoryMusicList
        {
            get { return this._historyMusicList; }
            set { if (this._historyMusicList != value)
                {
                    this._historyMusicList = value;
                } }
        }
        private List<MusicManager> _favouriteMusicList;
        /// <summary>
        /// 最爱列表
        /// </summary>
        public List<MusicManager> _FavouriteMusicList
        {
            get { return this._favouriteMusicList; }
            set
            {
                if (this._favouriteMusicList != value)
                {
                    this._favouriteMusicList = value;
                }
            }
        }
        #endregion


        #region 方法
        public void SearchMusic(string keywords)
        {

        }
        #endregion

    }
}
