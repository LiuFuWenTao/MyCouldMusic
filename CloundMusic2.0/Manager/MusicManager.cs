using CloudMusic.CloudApi.IApi;
using CloundMusic2._0.CloudApi.IApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace CloundMusic2._0.Manager
{
    /// <summary>
    /// 音乐接口管理类
    /// 负责管理音乐类的接口调用
    /// </summary>
    public class MusicManager
    {
        public MusicManager()
        {
            HttpApiConfig httpApiConfig = new HttpApiConfig();
            httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");
            MusicApi = HttpApiClient.Create<IMusicApi>(httpApiConfig);
        }
        public static IMusicApi MusicApi { get; set; }

    }
}
