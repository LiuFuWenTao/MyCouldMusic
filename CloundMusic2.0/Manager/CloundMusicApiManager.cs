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
    /// 接口管理者，对外提供接口的操作方式
    /// </summary>
    public class CloundMusicApiManager
    {
        public static IMusicApi MusicApi { get; set; }
        public CloundMusicApiManager()
        {
            HttpApiConfig httpApiConfig = new HttpApiConfig();
            httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");
            MusicApi = HttpApiClient.Create<IMusicApi>(httpApiConfig);
        }


    }
}
