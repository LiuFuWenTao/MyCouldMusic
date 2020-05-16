using CloundMusic2._0.CloudApi.IApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace CloundMusic2._0.CloudApi.ApiImp
{
    public class MusicApi 
    {


        public string AddOrDeleteSongToPlayList(string op, string pid)
        {
            return "";
        }

        public string CheckMusic(string id)
        {
            return "";
        }

        public string CreatePlaylist(string name)
        {
            return "";
        }

        public string DeletePlaylist(string name)
        {
            return "";
        }

        public string GetPlaylistSubscribers(string id)
        {
            return "";
        }

        public string GetSearchDefault()
        {
            return "";
        }

        public string GetSearchHot()
        {
            return "";
        }

        public string GetSearchHotDetail()
        {
            return "";
        }

        public string GetSearchSuggest(string keywords)
        {
            return "";
        }

        public string GetSongUrl(string id)
        {
            return "";
        }

        public string SearchMultimatch(string keywords)
        {
            return "";
        }

        public string SearchMusic(string keywords)
        {
            return "";
        }

        public string SubscribePlaylist(string t, string id)
        {
            return "";
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MusicApi() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
