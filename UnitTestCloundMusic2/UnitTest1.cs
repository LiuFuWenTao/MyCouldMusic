using System;
using CloundMusic2._0.CloudApi.IApi;
using CloundMusic2._0.Manager;
using CloundMusic2._0.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTestCloundMusic2
{
    [TestClass]
    public class UnitTest1 : BaseManager
    {
        private IMusicApi _musicServer = ServerManagerFactory.BuildMusicServerManager();


        [TestMethod]
        public void TestSearchMusic()
        {
            var keyword = "起风了";
            //通过这个接口来处理代码
            var reslut = InvokeAsyncTask(_musicServer.SearchMusic(keyword));
            //TODO 不过解析这快的代码我想抽取出去
            HttpSongBase httpSong = JsonConvert.DeserializeObject<HttpSongBase>(reslut);
            if (httpSong.Code == 200)
            {
                //属于正常情况
            }
        }

        [TestMethod]
        public void TestGetSongUrl()
        {
            var id = "1330348068";//起风了的音乐id
            var result = InvokeAsyncTask( _musicServer.GetSongUrl(id));
        }
        [TestMethod]
        public void TestGetMvUrl()
        {
            var id = "10782615";//起风了MVId
            var result = InvokeAsyncTask(_musicServer.GetMvUrl(id));
            //http://vodkgeyttp8.vod.126.net/cloudmusic/c012/core/185a/86b925a6d484c6a5c51a79fdb8215eed.mp4?wsSecret=23c1bb980d131d28661b0136179c04d6&wsTime=1598089209
        }
    }
}
