public class ServerManagerFactory{
    HttpApiConfig httpApiConfig = new HttpApiConfig();
    public ServerManagerFactory()
    {
        httpApiConfig = new HttpApiConfig();
        
        httpApiConfig.HttpHost = new Uri("http://music.rexhuang.top/");

    }

    ///构建用户的服务器请求实例
    public IUserApi BuildUserServerManager(){
        return HttpApiClient.Create<IUserApi>(httpApiConfig);
    }

    ///构建音乐部分的服务器请求实例
    public IMusicApi BuildMusicServerManager(){

        return HttpApiClient.Create<IMusicApi>(httpApiConfig);
    }
}