using CloundMusic2._0.CloudApi.IApi;
using System;
using WebApiClient;

/// <summary>
/// 接口管理工厂
/// </summary>
public static class ServerManagerFactory
{
    static HttpApiConfig httpApiConfig;
    public static IMusicApi MusicApi { get; set; }
    public static IUserApi UserApi { get; set; }
    static ServerManagerFactory()
    {
        httpApiConfig = new HttpApiConfig();
        httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");
    }

    ///构建用户的服务器请求实例
    public static IUserApi BuildUserServerManager()
    {
        if (UserApi == null)
        {
            UserApi = HttpApiClient.Create<IUserApi>(httpApiConfig);
        }
        return UserApi;
    }

    ///构建音乐部分的服务器请求实例
    public static IMusicApi BuildMusicServerManager()
    {
        if(MusicApi == null)
        {
            MusicApi = HttpApiClient.Create<IMusicApi>(httpApiConfig);
        }
        return MusicApi;
    }
}