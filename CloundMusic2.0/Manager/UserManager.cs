using CloundMusic2._0.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 用户管理者
    /// </summary>
    public class UserManager:IUserManager
    {
        private IUserApi serverUser = new ServerManagerFactory().BuildUserServerManager();
        // public User currentUser;
        public UserManager()
        {
            
        }
        ///加入歌单
        ///传入音乐id和歌单id
        ///但其实这个东西是调用服务器接口实现，本身并不本地处理，
        ///不过暂时如此吧，后续在准备一份本地化的接口，正好我的设计模式兼容这个情况
        public void AddToSongSheet(string musicId, string sheetId)
        {

        }

        ///删除歌单
        public void DeleteSheet(string sheetId)
        {

        }

        ///从歌单移除对应的歌曲
        public void DeleteMusicFromSheet(string musicId, string sheetId)
        {

        }
    }
}
