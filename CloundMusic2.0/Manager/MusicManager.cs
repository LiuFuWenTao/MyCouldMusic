using CloudMusic.CloudApi.IApi;
using CloundMusic2._0.CloudApi.IApi;
using CloundMusic2._0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace CloundMusic2._0.Manager
{
    /// <summary>
    /// 音乐管理类
    /// </summary>
    public class MusicManager : BaseManager, IMusicManager
    {
        private IMusicApi _musicServer = ServerManagerFactory.BuildMusicServerManager();


        ///找寻某一首歌曲，输入关键字，返回一个音乐实体列表，
        ///不过转换音乐的工作要放到工具类去做，单一职责原则
        public virtual Song[] SearchMusic(string keyword){
            //通过这个接口来处理代码
            var reslut = InvokeAsyncTask(_musicServer.SearchMusic(keyword));
            //TODO 不过解析这快的代码我想抽取出去
            HttpSongBase httpSong = JsonConvert.DeserializeObject<HttpSongBase>(reslut);
            if(httpSong.Code == 200)
            {
                //属于正常情况
            }
            return httpSong.Result.Songs;
        }

        public virtual string GetSongUrl(string id)
        {
            var reslut = InvokeAsyncTask(_musicServer.GetSongUrl(id));
            //TODO 不过解析这快的代码我想抽取出去
            HttpSongResponse songData = JsonConvert.DeserializeObject<HttpSongResponse>(reslut);
            if (songData.Code == 200)
            {
                //属于正常情况
            }
            //TODO  还有一块对数据的判断是否合理的代码
            return songData.Data[0].Url;
        }

        public virtual string GetMvUrl(string id)
        {
            return null;
        }

        ///输入评论
        ///用评论实体更好，因为这样后续如果实体发生变化，
        ///不需要修改接口，不过实体变化还是非常麻烦，修改起来容易出错
        ///最好还是一开始就写好对应的实体
        public virtual void WriteComment(Comment comment){

        }

        ///查看这首歌的所有评论，分页查询
        public virtual Comment[] OpenComment(string musicId, int size){
            return null;
        }

    }

}

