using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace CloundMusic2._0.CloudApi.IApi
{
    public interface IMusicApi : IHttpApi
    {
        

        /// <summary>
        /// 使用歌单详情接口后 , 能得到的音乐的 id, 但不能得到的音乐 url, 调用此接口 , 传入的音乐 id( 可多个 , 用逗号隔开 ), 可以获取对应的音乐的 url( 不需要登录 )
        /// ex: /song/url?id=33894312 /song/url?id=405998841,33894312
        /// 必选参数 : id : 音乐 id
        /// 可选参数 : br: 码率,默认设置了 999000 即最大码率,如果要 320k 则可设置为 320000, 其他类推
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/song/url")]
        ITask<string> GetSongUrl(string id);

        /// <summary>
        /// 调用此接口,传入歌曲 id, 可获取音乐是否可用,返回 { success: true, message: 'ok' } 或者 { success: false, message: '亲爱的,暂无版权' }
        /// ex: /check/music?id=33894312
        /// 必选参数 : id : 歌曲 id
        /// 可选参数 : br: 码率,默认设置了 999000 即最大码率,如果要 320k 则可设置为 320000, 其他类推
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/check/music")]
        ITask<string> CheckMusic(string id);

        /// <summary>
        /// 调用此接口 , 传入搜索关键词可以搜索该音乐 / 专辑 / 歌手 / 歌单 / 用户 , 关键词可以多个 , 以空格隔开 , 如 " 周杰伦 搁浅 "( 不需要登录 ), 搜索获取的 mp3url 不能直接用 , 可通过 /song/url 接口传入歌曲 id 获取具体的播放链接
        /// ex:/search?keywords= 海阔天空
        /// 必选参数 : keywords : 关键词
        /// 可选参数 : limit : 返回数量 , 默认为 30 offset : 偏移数量，用于分页 , 如 : 如 :(页数 -1)*30, 其中 30 为 limit 的值 , 默认为 0
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        [HttpGet("/search")]
        ITask<string> SearchMusic(string keywords);

        /// <summary>
        /// 调用此接口 , 可获取默认搜索关键词
        /// </summary>
        /// <returns></returns>
        [HttpGet("/search/default")]
        ITask<string> GetSearchDefault();

        /// <summary>
        /// 调用此接口,可获取热门搜索列表
        /// ex:/search/hot
        /// </summary>
        /// <returns></returns>
        [HttpGet("/search/hot")]
        ITask<string> GetSearchHot();

        /// <summary>
        /// 调用此接口,可获取热门搜索列表
        /// ex:/search/hot/detail
        /// </summary>
        /// <returns></returns>
        [HttpGet("/search/hot/detail")]
        ITask<string> GetSearchHotDetail();

        /// <summary>
        /// 调用此接口 , 传入搜索关键词可获得搜索建议 , 搜索结果同时包含单曲 , 歌手 , 歌单 ,mv 信息
        /// ex: /search/suggest?keywords= 海阔天空 /search/suggest?keywords= 海阔天空&type=mobile
        /// 必选参数 : keywords : 关键词
        /// 可选参数 : type : 如果传 'mobile' 则返回移动端数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("/search/suggest")]
        ITask<string> GetSearchSuggest(string keywords);

        /// <summary>
        /// 调用此接口 , 传入搜索关键词可获得搜索结果
        /// ex: /search/multimatch?keywords= 海阔天空
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        [HttpGet("/search/multimatch")]
        ITask<string> SearchMultimatch(string keywords);

        /// <summary>
        /// 调用此接口 , 传入歌单名字可新建歌单
        /// ex: /playlist/create?name=测试歌单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("/playlist/create")]
        ITask<string> CreatePlaylist(string name);

        /// <summary>
        /// 调用此接口 , 传入歌单id可删除歌单
        /// ex: /playlist/delete?id=2947311456
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("/playlist/delete")]
        ITask<string> DeletePlaylist(string name);

        /// <summary>
        ///  调用此接口 , 传入类型和歌单 id 可收藏歌单或者取消收藏歌单
        ///  ex: /playlist/subscribe?t=1&id=106697785 /playlist/subscribe?t=2&id=106697785
        ///  必选参数 :t : 类型,1:收藏,2:取消收藏 id : 歌单 id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/playlist/subscribe")]
        ITask<string> SubscribePlaylist(string t,string id);

        /// <summary>
        /// 调用此接口 , 传入歌单 id 可获取歌单的所有收藏者
        /// ex: /playlist/subscribers?id=544215255&limit=30
        /// 可选参数 : limit: 取出评论数量 , 默认为 20
        /// offset: 偏移数量 , 用于分页 , 如 :(评论页数 -1)*20, 其中 20 为 limit 的值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/playlist/subscribers")]
        ITask<string> GetPlaylistSubscribers(string id);


        /// <summary>
        /// 调用此接口 , 可以添加歌曲到歌单或者从歌单删除某首歌曲 ( 需要登录 )
        /// ex: /playlist/tracks?op=add&pid=24381616&tracks=347231 ( 对应把歌曲添加到 ' 我 ' 的歌单 , 测试的时候请把这里的 pid 换成你自己的, id 和 tracks 不对可能会报 502 错误)
        /// 必选参数 :
        /// op: 从歌单增加单曲为 add, 删除为 del
        /// pid: 歌单 id tracks: 歌曲 id, 可多个, 用逗号隔开
        /// </summary>
        /// <param name="op"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("/playlist/tracks")]
        ITask<string> AddOrDeleteSongToPlayList(string op,string pid);

        
    }
}
