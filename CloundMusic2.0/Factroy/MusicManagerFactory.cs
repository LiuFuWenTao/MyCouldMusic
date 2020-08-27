using Castle.DynamicProxy;
using CloundMusic2._0.Interceptor;
using CloundMusic2._0.Manager;
/// <summary>
/// 音乐工厂
/// </summary>
public static class MusicManagerFactory
{
    private static IMusicManager manager;

    public static IMusicManager Bulid()
    {
        if(manager == null)
        {
            //manager = new MusicManager(); //之前的工厂方法
            //现修改为拦截器代理方式
            manager = CreateLandlordProxy();
        }
        return manager;
    }

    /// <summary>
    /// 创建一个代理对象
    /// </summary>
    /// <returns></returns>
    private static IMusicManager CreateLandlordProxy()
    {
        ProxyGenerator proxyGenerator = new ProxyGenerator();
        MusicManager proyLandlord = proxyGenerator.CreateClassProxy<MusicManager>(new MusicManagerInterceptor());
        return proyLandlord;
    }
}