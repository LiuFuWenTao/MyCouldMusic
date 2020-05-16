using System;
using CloudMusic.CloudApi.IApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiClient;

namespace UnitTestApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            try
            {
                HttpApiConfig httpApiConfig = new HttpApiConfig();
                httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");
                var myWebApi = HttpApiClient.Create<IMusicCloundApi>(httpApiConfig);
                var s = await myWebApi.GetMusicTpye();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
