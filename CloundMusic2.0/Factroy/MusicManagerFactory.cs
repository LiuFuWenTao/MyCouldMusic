using Castle.DynamicProxy;
using CloundMusic2._0.Interceptor;
using CloundMusic2._0.Manager;
/// <summary>
/// ���ֹ���
/// </summary>
public static class MusicManagerFactory
{
    private static IMusicManager manager;

    public static IMusicManager Bulid()
    {
        if(manager == null)
        {
            //manager = new MusicManager(); //֮ǰ�Ĺ�������
            //���޸�Ϊ����������ʽ
            manager = CreateLandlordProxy();
        }
        return manager;
    }

    /// <summary>
    /// ����һ���������
    /// </summary>
    /// <returns></returns>
    private static IMusicManager CreateLandlordProxy()
    {
        ProxyGenerator proxyGenerator = new ProxyGenerator();
        MusicManager proyLandlord = proxyGenerator.CreateClassProxy<MusicManager>(new MusicManagerInterceptor());
        return proyLandlord;
    }
}