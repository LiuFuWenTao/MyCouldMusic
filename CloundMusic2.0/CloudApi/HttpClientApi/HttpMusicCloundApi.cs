using CloundMusic2._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace CloudMusic.CloudApi.IApi
{
    [HttpHost("http://music.rexhuang.top/")]
    public interface IMusicCloundApi : IHttpApi
    {
        /// <summary>
        /// 获取歌单分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("/playlist/catlist")]
        ITask<string> GetMusicTpye();
    }
}
