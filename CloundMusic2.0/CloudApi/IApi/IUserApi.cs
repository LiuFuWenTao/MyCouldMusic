using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace CloundMusic2._0.CloudApi.IApi
{
    public interface IUserApi :  IHttpApi
    {

        /// <summary>
        /// 登录
        /// Ex: /login?email=xxx@163.com&password=yyy
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet("/login")]
        ITask<string> Login(string email, string password);
        
        /// <summary>
        /// 手机登录
        /// Ex: /login/cellphone? phone = xxx & password = yyy
        /// </summary>
        /// <param name="phone">手机</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet("/login/cellphone")]
        ITask<string> Cellphone(string phone, string password);
        
        /// <summary>
        /// 刷新登录状态
        /// </summary>
        /// <returns></returns>
        [HttpGet("/login/refresh")]
        ITask<string> Refresh();
        
        /// <summary>
        /// 传入手机号码, 可发送验证码
        /// Ex: /captcha/sent?phone=13xxx
        /// </summary>
        /// <param name="phone">手机</param>
        /// <returns></returns>
        [HttpGet("/captcha/sent")]
        ITask<string> Sent(string phone);

        /// <summary>
        /// 传入手机号码和验证码, 可校验验证码是否正确
        /// Ex: /captcha/verify?phone=13xxx&captcha=1597
        /// </summary>
        /// <param name="phone">手机</param>
        /// <returns></returns>
        [HttpGet("/captcha/verify")]
        ITask<string> Verify(string phone,string captcha);

        /// <summary>
        /// 传入手机号码和验证码,密码,昵称, 可注册网易云音乐账号(同时可修改密码)
        /// Ex: /register/cellphone?phone=13xxx&password=xxxxx&captcha=1234&nickname=binary1345
        /// </summary>
        /// <returns></returns>
        [HttpGet("/register/cellphone")]
        ITask<string> RegisterOrChangePassword(string phone,string password, string captcha,string nickname);

        /// <summary>
        /// 可检测手机号码是否已注册 
        /// Ex: /cellphone/existence/check?phone=13xxx
        /// </summary>
        /// <returns></returns>
        [HttpGet("/cellphone/existence/check")]
        ITask<string> CheckPhone(string phone, string password, string captcha, string nickname);

        /// <summary>
        /// 刚注册的账号(需登录),调用此接口 ,可初始化昵称
        /// Ex: /activate/init/profile?nickname=testUser2019
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <returns></returns>
        [HttpGet("/activate/init/profile")]
        ITask<string> InitUserName(string nickname);
        /// <summary>
        /// 
        /// ex /rebind?phone=xxx&oldcaptcha=1234&captcha=5678
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        [HttpGet("/rebind")]
        ITask<string> Rebind(string phone,string oldcaptcha,string captcha);

        /// <summary>
        ///  退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("/logout")]
        ITask<string> Logout();
        /// <summary>
        ///  文档损坏，未测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("/login/status")]
        ITask<string> Status();

        /// <summary>
        ///  登陆后调用此接口 , 传入用户 id, 可以获取用户详情
        ///  ex:/user/detail?uid=32953014
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/detail")]
        ITask<string> Detail(string uid);

        /// <summary>
        ///  登陆后调用此接口 , 可以获取用户信息
        /// ex /user/subcount
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/subcount")]
        ITask<string> Subcount(string uid);

        /// <summary>
        /// 登陆后调用此接口 , 传入相关信息,可以更新用户信息
        /// ex:/user/update?gender=0&signature=测试签名&city=440300&nickname=binary&birthday=1525918298004&province=440000
        /// gender: 性别 0:保密 1:男性 2:女性
        /// birthday: 出生日期,时间戳 unix timestamp
        /// nickname: 用户昵称
        /// province: 省份id
        /// city: 城市id
        /// signature：用户签名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/update")]
        ITask<string> Update(int gender,DateTime birthday,string nickname,string province,string city,string signature);

        /// <summary>
        ///  登陆后调用此接口 , 传入用户 id, 可以获取用户歌单
        ///  ex:/user/playlist?uid=32953014
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/playlist")]
        ITask<string> Playlist(string uid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">歌单id</param>
        /// <param name="name">歌单名字</param>
        /// <param name="desc">歌单描述</param>
        /// <param name="tags">歌单tag ,多个用 `;` 隔开,只能用官方规定标签</param>
        /// <returns></returns>
        [HttpGet("/user/playlist")]
        ITask<string> PlaylistUpdate(string id,string name,string desc,string tags);

        /// <summary>
        /// 更新歌单描述
        /// 恶心：/playlist/desc/update?id=24381616&desc=描述
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desc"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet("/playlist/desc/update")]
        ITask<string> PlaylistDescUpdate(string id, string desc);

        /// <summary>
        ///  登陆后调用此接口,可以单独更新用户歌单名 参数:
        ///  ex:/playlist/name/update?id=24381616&name=歌单名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("/playlist/name/update")]
        ITask<string> PlaylistNameUpdate(string id, string name);

        /// <summary>
        /// 登陆后调用此接口,可以单独更新用户歌单标签 
        /// ex : /playlist/tags/update?id=24381616&tags=学习
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        [HttpGet("/playlist/tags/update")]
        ITask<string> PlaylistTagsUpdate(string id, string tags);

        /// <summary>
        /// 登陆后调用此接口 , 传入用户 id, 可以获取用户电台
        /// ex: /user/dj?uid=32953014
        /// </summary>
        /// <param name="dj"></param>
        /// <returns></returns>
        [HttpGet("/user/dj")]
        ITask<string> GetUserDj(string dj);

        /// <summary>
        /// 登陆后调用此接口 , 传入用户 id, 可以获取用户关注列表
        /// ex : /user/follows?uid=32953014
        ///  limit : 返回数量 , 默认为 30
        ///offset : 偏移数量，用于分页 , 如 : 如 :(页数 -1)*30, 其中 30 为 limit 的值 , 默认为 0
        /// </summary>
        /// <param name="dj"></param>
        /// <returns></returns>
        [HttpGet("/user/follows")]
        ITask<string> GetUserFollows(string uid);


        /// <summary>
        ///   登陆后调用此接口 , 传入用户 id, 可以获取用户粉丝列表
        ///   ex: /user/followeds?uid=32953014 /user/followeds?uid=416608258&time=1560152549136
        ///   可选参数 : limit : 返回数量 , 默认为 30
        ///   lasttime : 返回数据的 lasttime ,默认-1,传入上一次返回结果的 lasttime,将会返回下一页的数据
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/followeds")]
        ITask<string> GetUserFolloweds(string uid);

        /// <summary>
        ///  登陆后调用此接口 , 传入用户 id, 可以获取用户动态
        ///  ex: /user/event?uid=32953014  /user/event?uid=32953014&limit=1&lasttime=1558011138743
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/event")]
        ITask<string> GetUserEvent(string uid);

        /// <summary>
        /// 登陆后调用此接口 ,可以转发用户动态
        /// ex: /event/forward?evId=6712917601&uid=32953014&forwards=测试内容
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/forward")]
        ITask<string> ForwardUserEvent(string uid);

        /// <summary>
        ///  登陆后调用此接口 ,可以删除用户动态
        /// </summary>
        /// <param name="evId"></param>
        /// <returns></returns>
        [HttpGet("/event/del")]
        ITask<string> DeleteUserEvent(string evId);

        /// <summary>
        /// 登陆后调用此接口 ,可以分享歌曲、歌单、mv、电台、电台节目到动态
        /// ex: /share/resource?id=1297494209&msg=测试 /share/resource?type=djradio&id=336355127 /share/resource?type=djprogram&id=2061034798 /share/resource?type=djprogram&id=2061034798&msg=测试@binaryify 测试
        /// id : 资源 id （歌曲，歌单，mv，电台，电台节目对应 id）
        /// type: 资源类型，默认歌曲 song，可传 song,playlist,mv,djradio,djprogram
        /// msg: 内容，140 字限制，支持 emoji，@用户名（/user/follows接口获取的用户名，用户名后和内容应该有空格），图片暂不支持
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/share/resource")]
        ITask<string> ShareResource(string id);

        /// <summary>
        /// 登陆后调用此接口 , 可以获取动态下评论
        /// ex: /comment/event?threadId=A_EV_2_6559519868_32953014
        /// 必选参数 : threadId : 动态 id，可通过 /event，/user/event 接口获取
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [HttpGet("/comment/event")]
        ITask<string> GetEventComment(string threadId);

        /// <summary>
        /// 登陆后调用此接口 , 传入用户 id, 和操作 t,可关注/取消关注用户
        /// ex: /follow?id=32953014&t=1
        /// id : 用户 id
        /// t : 1为关注,其他为取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet("/follow")]
        ITask<string> FollowUser(string id,string t);

        /// <summary>
        /// 登陆后调用此接口 , 传入用户 id, 可获取用户播放记录
        /// ex: /user/record?uid=32953014&type=1
        /// 必选参数 : uid : 用户 id
        /// 可选参数 : type : type=1 时只返回 weekData, type=0 时返回 allData
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet("/user/record")]
        ITask<string> GetUserRecord(string uid);

        /// <summary>
        /// 调用此接口 , 可获取热门话题
        /// ex: /hot/topic?limit=30&offset=30
        /// 可选参数 : limit: 取出评论数量 , 默认为 20
        ///offset: 偏移数量 , 用于分页 , 如 :(评论页数 -1)*20, 其中 20 为 limit 的值
        /// </summary>
        /// <returns></returns>
        [HttpGet("/hot/topic")]
        ITask<string> GetHotTopic();

        /// <summary>
        /// 登录后调用此接口 , 可获取云村热评
        /// ex:/comment/hotwall/list
        /// </summary>
        /// <returns></returns>
        [HttpGet("/comment/hotwall/list")]
        ITask<string> GetCommentHotTopic();

        /// <summary>
        /// 登录后调用此接口 , 可获取心动模式/智能播放列表
        /// ex: /playmode/intelligence/list?id=33894312&pid=24381616 , /playmode/intelligence/list?id=33894312&pid=24381616&sid=36871368
        /// 必选参数 : id : 歌曲 id
        /// pid : 歌单 id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("/playmode/intelligence/list")]
        ITask<string> PlayinteIligenceList(string id,string pid);

        /// <summary>
        /// 调用此接口 , 可获取各种动态 , 对应网页版网易云，朋友界面里的各种动态消息 ，如分享的视频，音乐，照片等！
        /// ex:/event?pagesize=30&lasttime=1556740526369
        /// 必选参数 :  pagesize : 每页数据,默认20
        /// lasttime : 返回数据的 lasttime ,默认-1,传入上一次返回结果的 lasttime,将会返回下一页的数据
        /// </summary>
        /// <param name="pagesize "></param>
        /// <param name="lasttime "></param>
        /// <returns></returns>
        [HttpGet("/event")]
        ITask<string> PlayinteIligenceList(int pagesize, string lasttime="-1");

        /// <summary>
        /// 调用此接口,可获取歌手分类列表
        /// cat : 即 category Code,歌手类型,默认 1001,返回华语男歌手数据
        /// 入驻歌手 5001

        ///        华语男歌手 1001

        //华语女歌手 1002

        //华语组合/乐队 1003

        //欧美男歌手 2001

        //欧美女歌手 2002

        //欧美组合/乐队 2003

        //日本男歌手 6001

        //日本女歌手 6002

        //日本组合/乐队 6003

        //韩国男歌手 7001

        //韩国女歌手 7002

        //韩国组合/乐队 7003

        //其他男歌手 4001

        //其他女歌手 4002

        //其他组合/乐队 4003
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpGet("/artist/list")]
        ITask<string> GetArtistList(string  cat);

        /// <summary>
        /// 调用此接口,可收藏歌手
        /// ex: /artist/sub?id=6452&t=1
        /// artistId : 歌手 id
        /// t:操作,1 为收藏,其他为取消收藏
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet("/artist/sub")]
        ITask<string> SubArtist(string artistId,string t);

        /// <summary>
        /// 调用此接口,可获取
        /// ex: /artist/top/song?id=6452
        /// id : 歌手 id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/artist/top/song")]
        ITask<string> GetArtistTopSong(string id);

        /// <summary>
        /// 调用此接口,可获取收藏的歌手列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/artist/sublist")]
        ITask<string> GetArtistSublist();

        /// <summary>
        /// 调用此接口,可收藏视频
        /// ex: /video/sub
        /// id : 视频 id
        /// t : 1 为收藏,其他为取消收藏
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet("/video/sub")]
        ITask<string> SubVideo(string id,string t);

        /// <summary>
        /// 调用此接口,可收藏/取消收藏 MV
        /// ex: /mv/sub
        /// </summary>
        /// <param name="mvid"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet("/mv/sub")]
        ITask<string> SubMV(string mvid, string t);

        /// <summary>
        /// 调用此接口,可获取收藏的 MV 列表
        /// ex: /mv/sublist
        /// </summary>
        /// <returns></returns>
        [HttpGet("/mv/sublist")]
        ITask<string> GetSublist();

        /// <summary>
        /// 调用此接口,可获取歌单分类,包含 category 信息
        /// ex: /playlist/catlist
        /// </summary>
        /// <returns></returns>
        [HttpGet("/playlist/catlist")]
        ITask<string> GetCatlist();

        /// <summary>
        /// 调用此接口,可获取歌单分类,包含 category 信息
        /// ex: /playlist/hot
        /// </summary>
        /// <returns></returns>
        [HttpGet("/playlist/hot")]
        ITask<string> GetHotPlaylist();

        /// <summary>
        /// 调用此接口 , 可获取网友精选碟歌单
        /// ex: /top/playlist?limit=10&order=new
        /// order: 可选值为 'new' 和 'hot', 分别对应最新和最热 , 默认为 'hot'
        /// cat:cat: tag, 比如 " 华语 "、" 古风 " 、" 欧美 "、" 流行 ", 默认为 "全部",可从歌单分类接口获取(/playlist/catlist)
        /// </summary>
        /// <returns></returns>
        [HttpGet("/top/playlist")]
        ITask<string> GetTopPlaylist();

        /// <summary>
        /// 调用此接口 , 可获取精品歌单
        /// ex: http://localhost:3000/top/playlist/highquality?before=1503639064232&limit=3
        /// 可选参数 : cat: tag, 比如 " 华语 "、" 古风 " 、" 欧美 "、" 流行 ", 默认为 "全部",可从歌单分类接口获取(/playlist/catlist)
        /// limit: 取出歌单数量 , 默认为 20
        /// before: 分页参数,取上一页最后一个歌单的 updateTime 获取下一页数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("/top/playlist/highquality")]
        ITask<string> GetHighqualityPlaylist();

        /// <summary>
        /// 调用此接口,传入歌单 id 可获取相关歌单(对应页面 https://music.163.com/#/playlist?id=1)
        /// ex: /related/playlist?id=1
        /// 必选参数 : id : 歌单 id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/related/playlist")]
        ITask<string> GetRelatedPlaylist(string id);

        /// <summary>
        /// 歌单能看到歌单名字 , 但看不到具体歌单内容 , 调用此接口 , 传入歌单 id, 可 以获取对应歌单内的所有的音乐，但是返回的trackIds是完整的，tracks 则是不完整的，可拿全部 trackIds 请求一次 song/detail 接口获取所有歌曲的详情 (https://github.com/Binaryify/NeteaseCloudMusicApi/issues/452)
        /// 
        /// ex:/playlist/detail?id=24381616
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/playlist/detail")]
        ITask<string> GetDetailPlaylist(string id);
        
    }
}
